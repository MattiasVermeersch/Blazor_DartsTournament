namespace Pin.DartsTournament.Blazor.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(long? id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity); 
        Task<bool> DeleteAsync(long id);
    }
}
