namespace Services.Decorators;

public class LoggingDecorator<T>(IRepository<T> inner) : IRepository<T> where T : class
{
    public async Task<T> GetByIdAsync(int id, Tracking tracking)
    {
        Log.Information($"Getting {typeof(T)} with id {id}");

        var entity = await inner.GetByIdAsync(id, tracking);

        if (entity is null)
        {
            Log.Information($"there is no {typeof(T)} with id {id}");

            return entity!;
        }

        Log.Information($"Got {typeof(T)} with id {id}");

        return entity!;
    }
    public IQueryable<T> GetAsync(Tracking tracking)
    {
        Log.Information("Getting {@EntityType}s", typeof(T));

        var result = inner.GetAsync(tracking);

        if (result == null || !result.Any())
        {
            Log.Information("{@EntityType}s is empty", typeof(T));

            return result!;
        }

        Log.Information("Got {@EntityType}s", typeof(T));

        return result!;
    }
    public IQueryable<T> GetAsyncWhere(Expression<Func<T, bool>> filter, Tracking tracking)
    {
        Log.Information("Getting {@EntityType}s with {@Filter}", typeof(T), filter.Body);

        var result = inner.GetAsyncWhere(filter, tracking);

        if (result == null || !result.Any())
        {
            Log.Information("{@EntityType}s is empty", typeof(T));

            return result!;
        }

        Log.Information("Got {@EntityType}s with {@Filter}", typeof(T), filter.Body);

        return result!;
    }
    public async Task<bool> UpdateAsync(T entity, int id)
    {
        Log.Information("Update {@EntityType} with id {@id}", entity, id);

        var result = await inner.UpdateAsync(entity, id);

        if (result)
        {
            Log.Information("Updated {@EntityType} with id {@id}", entity, id);

            return result!;
        }

        Log.Information("Update {@EntityType} with id {@id} failed", entity, id);

        return result;
    }
    public async Task<T> CreateAsync(T entity, int id)
    {
        Log.Information("Creating {@EntityType} {@Entity}", typeof(T), entity);

        var result = await inner.CreateAsync(entity, id);

        if (result is null)
        {
            Log.Information("Created {@EntityType} {@Entity} failed", typeof(T).Name, result);

            return result!;
        }

        Log.Information("Created {@EntityType} {@Entity}", typeof(T).Name, result);

        return result;
    }
    public async Task<bool> DeleteAsync(T entity, int id)
    {
        Log.Information("Deleting {@EntityType} with id {@id}", typeof(T), id);

        var result = await inner.DeleteAsync(entity, id);

        Log.Information("Deleted {@EntityType} with id {@id}", typeof(T), id);

        return result;
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        Log.Information("Deleting {@EntityType} {@Entity}", typeof(T).Name, entities);

        var result = await inner.DeleteRangeAsync(entities);

        Log.Information("Deleted {@EntityType} {@Entity}", typeof(T).Name, result);

        return result;
    }
    public async Task BeginTransaction()
    {

        Log.Information($"Begin Transaction {DateTime.Now}");

        await inner.BeginTransaction();

        Log.Information($"End Transaction {DateTime.Now}");
    }
    public async Task CommitTransaction()
    {

        Log.Information($"Commit Transaction {DateTime.Now}");

        await inner.CommitTransaction();
    }
    public async Task RollBack()
    {
        Log.Information($"RollBack Transaction {DateTime.Now}");

        await inner.RollBack();
    }
    public async Task SaveChangesAsync()
    {

        Log.Information($"Saving Changes {DateTime.Now}");

        await inner.SaveChangesAsync();
    }
}


