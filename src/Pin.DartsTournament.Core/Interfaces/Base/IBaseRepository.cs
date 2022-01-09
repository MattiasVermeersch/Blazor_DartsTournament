using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Core.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAllAsync();
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(long? id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(long? id);
    }
}
