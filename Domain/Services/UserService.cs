using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> DeleteAsync(User user)
        {
            return await _userRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> InsertAsync(User entity)
        {
            return await _userRepository.InsertAsync(entity);
        }

        public async Task<User> UpdateAsync(Guid id, User entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }

    }
}
