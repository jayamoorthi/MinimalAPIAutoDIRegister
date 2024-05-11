using Common.MicroService.Domain.Interfaces;
using Common.MicroService.Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPIAutoDIRegister.PipeLineBehaviour
{
    public class IdempotencyService:IIdempotecyService
    {
        private readonly InventoryDbContext _dbContext;
        public IdempotencyService(InventoryDbContext  dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task CreateRequestAsync(Guid requestId, string name)
        {
            var request = new IdempotencyRequest
            {
                RequestId = requestId,
                RequestName = name,
                OnCreatedAt = DateTime.UtcNow,
            };
           _dbContext.Set<IdempotencyRequest>().Add(request);
           await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> RequestExistsAsync(Guid requestId)
        {
            return await _dbContext.Set<IdempotencyRequest>().AnyAsync(x=> x.RequestId == requestId);
        }
    }
}
