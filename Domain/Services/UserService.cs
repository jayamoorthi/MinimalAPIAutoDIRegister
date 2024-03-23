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
        public async Task<LoginUser> DeleteAsync(LoginUser user)
        {
            return await _userRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<LoginUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<LoginUser?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<LoginUser> InsertAsync(LoginUser entity)
        {
            return await _userRepository.InsertAsync(entity);
        }

        public async Task<LoginUser> UpdateAsync(Guid id, LoginUser entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }

    }
}
