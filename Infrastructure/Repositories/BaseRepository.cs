using Domain.BaseDomain;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<T> _entities;

        protected BaseRepository(InventoryDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.AsNoTracking().ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) =>
            await _entities.AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == id);

        public async Task<T> InsertAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
           

            if (entity is null)
                throw new ArgumentNullException(nameof(entity.Id));

            var entityId = _entities.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (entityId is null)
                throw new RecordNotFoundException(nameof(entity.Id));

            _entities.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var entityId = _entities.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (entityId is null)
                throw new RecordNotFoundException(nameof(entity.Id));

            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
