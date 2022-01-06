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
    public class BaseService<T> : IBaseService<T> 
        where T : EntityBase
    {
        protected readonly DartsDbContext _dbContext;

        public BaseService(DartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> GetAllAsync()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            var result = await _dbContext.SaveChangesAsync();

            return CheckContextChanges(result);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            var result = await _dbContext.SaveChangesAsync();

            return CheckContextChanges(result);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            var result = await _dbContext.SaveChangesAsync();

            return CheckContextChanges(result);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            T entity = await GetByIdAsync(id);
            return await DeleteAsync(entity);
        }

        private bool CheckContextChanges(int result)
        {
            if (result == 1) return true;
            else return false;
        } 
        
    }
}
