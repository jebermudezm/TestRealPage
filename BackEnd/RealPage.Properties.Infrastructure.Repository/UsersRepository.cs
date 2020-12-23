using Microsoft.EntityFrameworkCore;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Infrastructure.Interface;
using RealPage.Properties.Infrastructure.Repository.Base;
using System.Threading.Tasks;

namespace RealPage.Properties.Infrastructure.Repository
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        
        public UsersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            }
            catch (System.Exception e)
            {

                throw;
            }
            
        }
    }
}
