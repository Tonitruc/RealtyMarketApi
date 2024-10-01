using RealtyMarketApi.Models;

namespace RealtyMarketApi.Repository
{
    public class UserRepository : EfCoreRepository<User, ApplicationDbContext>
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<User?> GetUserByEmail(string email)
        {
            List<User> users = await GetAll();
            User? existUser = users.FirstOrDefault(user => user.Email == email);
            return existUser;
        }
    }
}
