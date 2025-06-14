namespace Services.GenericRepository;

public interface IRepository<T> where T : class, IEntity
{
    Task<bool> UpdateAsync(T entity, int id);
    Task<bool> DeleteAsync(T entity, int id);
    Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
    Task<bool> CreateAsync(T entity, CancellationToken cancellationToken);
}
