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
        Task<IEnumerable<LoginUser>> GetAllAsync();
        Task<LoginUser?> GetByIdAsync(Guid id);
        Task<LoginUser> InsertAsync(LoginUser entity);
        Task<LoginUser> UpdateAsync(Guid id, LoginUser entity);
        Task<LoginUser> DeleteAsync(LoginUser entity);

        Task<List<LoginUser>?> GetTemporalByIdAsync(Guid id);
    }
}
