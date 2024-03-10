using Domain.BaseDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User> InsertAsync(User entity);
        Task<User> UpdateAsync(Guid id, User entity);
        Task<User> DeleteAsync(User entity);
    }
}
