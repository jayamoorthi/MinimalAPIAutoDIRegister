using Domain.BaseDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository: IRepository<LoginUser>
    {
        Task<List<LoginUser>?> GetTemporalAllUsersQueryAsync(Guid id);
    }
}
