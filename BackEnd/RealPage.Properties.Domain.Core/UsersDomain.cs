using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Domain.Interface;
using RealPage.Properties.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPage.Properties.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> Authenticate(string userName, string password)
        {
            return await _usersRepository.Authenticate(userName, password);
        }

        public async Task<bool> Add(User user)
        {
            try
            {
                await _usersRepository.AddAsync(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                await _usersRepository.UpdateAsync(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int userId)
        {
            try
            {
                var prop = await _usersRepository.GetByIdAsync(userId);
                await _usersRepository.DeleteAsync(prop);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> Get(int userId)
        {
            return await _usersRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _usersRepository.GetAllAsync();
        }
    }
}
