using Common.MicroService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MicroService.Domain.Interfaces
{
    public interface IIdempotecyService
    {
        Task<bool> RequestExistsAsync(Guid requestId);
        Task CreateRequestAsync(Guid requestId, string name);
        
    }
}
 