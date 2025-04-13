namespace Services.GenericRepository;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id, Tracking tracking);
    IQueryable<T> GetAsync(Tracking tracking);
    IQueryable<T> GetAsyncWhere(Expression<Func<T, bool>> filter, Tracking tracking);
    Task<bool> UpdateAsync(T entity, int id);
    Task<bool> DeleteAsync(T entity, int id);
    Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
    Task<T> CreateAsync(T entity, int id);
    Task SaveChangesAsync();
    Task BeginTransaction();
    Task CommitTransaction();
    Task RollBack();
}
