namespace Services.GenericRepository;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly AppDbContext context = context;
    protected readonly DbSet<T> dbSet = context.Set<T>();
    public virtual async Task<bool> UpdateAsync(T entity, int id)
    {
        dbSet.Update(entity);

        return await Task.FromResult(true);
    }
    public virtual async Task<bool> DeleteAsync(T entity, int id)
    {
        dbSet.Remove(entity);

        return await Task.FromResult(true);
    }
    public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);

        return await Task.FromResult(true);
    }
    public virtual async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await dbSet.AddAsync(entity, cancellationToken);

        return true;
    }
}
