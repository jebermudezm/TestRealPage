using RealPage.Properties.Application.DTO;
using RealPage.Properties.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Application.Interface
{
    public interface IUsersApplication
    {
        Task<Response<UsersDto>> Authenticate(string username, string password);
        Task<Response<bool>> Add(UsersDto userDto);
        Task<Response<bool>> Update(UsersDto userDto);
        Task<Response<bool>> Delete(int userId);
        Task<Response<UsersDto>> Get(int userId);
        Task<Response<IEnumerable<UsersDto>>> GetAll();
    }
}
