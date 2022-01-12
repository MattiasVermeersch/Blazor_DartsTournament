using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Core.Interfaces;
using Pin.DartsTournament.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Services
{
    public class BaseRepository<T> : IBaseRepository<T> 
        where T : EntityBase
    {
        protected readonly DartsDbContext _dbContext;
        protected DbSet<T> _table;

        public BaseRepository(DartsDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAllAsync()
        {
            return _table.AsNoTracking();
        }

        public virtual async Task<T> GetByIdAsync(long? id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                await _table.AddAsync(entity);

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var dbEntity = await _table.FindAsync(entity.Id);

                //compare and change properties on entity and dbEntity

                await _dbContext.SaveChangesAsync();

                return await GetByIdAsync(entity.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity);

                var result = await _dbContext.SaveChangesAsync();

                if (result > 0) return true;
                else return false;
            }
            catch(DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteByIdAsync(long? id)
        {
            T entity = await GetByIdAsync(id);
            return await DeleteAsync(entity);
        }
    }
}
