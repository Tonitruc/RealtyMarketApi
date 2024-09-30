using System.Security.Principal;
using RealtyMarketApi.Models;

namespace RealtyMarketApi.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T?> Get(long id);
        Task<T?> Add(T entity);
        Task<T?> Update(T entity);
        Task<bool> Delete(long id);
    }
}
