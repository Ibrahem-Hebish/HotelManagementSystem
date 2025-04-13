namespace Services.GenericRepository;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    public async Task<T> GetByIdAsync(int id, Tracking tracking)
    {
        if (tracking == Tracking.AsTracking)
        {
            var entity = await context.Set<T>()
                                       .FindAsync(id);

            return entity!;
        }
        else
        {
            var entity = await context.Set<T>()
                                       .AsNoTracking()
                                        .SingleOrDefaultAsync(x => EF.Property<int>(x, "Id") == id); ;

            return entity!;
        }
    }
    public IQueryable<T> GetAsync(Tracking tracking)
    {
        if (tracking == Tracking.AsTracking)
        {
            var entities = context.Set<T>();

            return entities;
        }
        else
        {
            var entities = context.Set<T>().AsNoTracking();

            return entities;
        }
    }
    public IQueryable<T> GetAsyncWhere(Expression<Func<T, bool>> filter, Tracking tracking)
    {
        if (tracking == Tracking.AsTracking)
        {
            var entities = context.Set<T>()
                                   .Where(filter);

            return entities;
        }
        else
        {
            var entities = context.Set<T>()
                                   .AsNoTracking()
                                    .Where(filter);

            return entities;
        }
    }
    public async Task<bool> UpdateAsync(T entity, int id)
    {
        context.Set<T>().Update(entity);

        await SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(T entity, int id)
    {
        context.Set<T>().Remove(entity);

        await SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        context.Set<T>().RemoveRange(entities);

        await SaveChangesAsync();

        return true;
    }
    public async Task<T> CreateAsync(T entity, int id)
    {
        var createdEntery = await context.Set<T>().AddAsync(entity);

        await context.SaveChangesAsync();

        return createdEntery.Entity;
    }
    public async Task BeginTransaction()
    {
        await context.Database.BeginTransactionAsync();
    }
    public async Task CommitTransaction()
    {
        await context.Database.CommitTransactionAsync();
    }
    public async Task RollBack()
    {
        await context.Database.RollbackTransactionAsync();
    }
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
