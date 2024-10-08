﻿using Microsoft.EntityFrameworkCore;

namespace RealtyMarketApi.Repository
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
            where TEntity : class, IEntity
            where TContext : DbContext
    {
        private readonly TContext context;

        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity?> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> Get(long id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
