using RealPage.Properties.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Domain.Interface
{
    public interface IUsersDomain
    {
        Task<User> Authenticate(string username, string password);
        Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int userId);
        Task<User> Get(int userId);
        Task<IEnumerable<User>> GetAll();
    }
}
