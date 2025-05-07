namespace Services.GenericRepository;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly AppDbContext context = context;
    protected readonly DbSet<T> dbSet = context.Set<T>();
    public virtual async Task<T> GetByIdAsync(int id, Tracking tracking,
                                       CancellationToken cancellationToken)
    {
        if (tracking == Tracking.AsTracking)
        {
            var entity = await dbSet.FindAsync([id], cancellationToken);

            return entity!;
        }
        else
        {
            var entity = await dbSet.AsNoTracking()
                                        .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity!;
        }
    }
    public virtual async Task<List<T>> GetAsync(Tracking tracking)
    {
        if (tracking == Tracking.AsTracking)
        {
            var entities = dbSet;

            await Task.CompletedTask;

            return await entities.ToListAsync();
        }
        else
        {
            var entities = await dbSet.AsNoTracking().ToListAsync();

            return entities;
        }
    }
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
