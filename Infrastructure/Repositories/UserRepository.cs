using Domain.BaseDomain.DomainModels;
using Domain.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<LoginUser>, IUserRepository
    {
        private readonly InventoryDbContext _inventoryDbContext;
        public UserRepository(InventoryDbContext context) : base(context)
        {
            _inventoryDbContext = context;
        }


        //public async Task<InventoryStock> SaveInventoryStockAsync(InventoryStock inventoryStock)
        //{
        //    await _inventoryDbContext.InventoryStock.AddAsync(inventoryStock);
        //    await _inventoryDbContext.SaveChangesAsync();
        //    return inventoryStock;
        //}

    }
}
