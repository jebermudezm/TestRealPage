using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Infrastructure.Interface.Base;
using System.Threading.Tasks;

namespace RealPage.Properties.Infrastructure.Interface
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}
