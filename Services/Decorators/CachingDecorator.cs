namespace Services.Decorators;

public class CachingDecorator<T>(IMemoryCache cache, IRepository<T> inner) : IRepository<T> where T : class
{
    public IQueryable<T> GetAsync(Tracking tracking)
    {
        var cachedKey = $"{typeof(T).Name}";

        if (!cache.TryGetValue(cachedKey, out IQueryable<T>? result))
        {
            var entities = inner.GetAsync(tracking);

            if (entities is not null && entities.Any())
                cache.Set(cachedKey, entities);

            return entities!;
        }

        return result!;
    }
    public IQueryable<T> GetAsyncWhere(Expression<Func<T, bool>> filter, Tracking tracking)
    {
        var cachedKey = $"{typeof(T).Name},{filter.Parameters.GetHashCode()}";

        if (!cache.TryGetValue(cachedKey, out IQueryable<T>? result))
        {
            var entities = inner.GetAsyncWhere(filter, tracking);

            if (entities is not null && entities.Any())
                cache.Set(cachedKey, entities);

            return entities!;
        }

        return result!;
    }
    public async Task<T> GetByIdAsync(int id, Tracking tracking)
    {
        var cachedKey = $"{typeof(T).Name} with id {id}";

        if (!cache.TryGetValue(cachedKey, out T? result))
        {
            var entity = await inner.GetByIdAsync(id, tracking);

            if (entity is not null)
                cache.Set(cachedKey, entity);

            return entity!;
        }

        return result!;
    }
    public async Task<T> CreateAsync(T entity, int id)
    {
        var cachedKey = $"{typeof(T).Name}";

        cache.Remove(cachedKey);

        return await inner.CreateAsync(entity, id);
    }
    public async Task<bool> UpdateAsync(T entity, int id)
    {
        var cachedKey = $"{typeof(T).Name}";

        cache.Remove(cachedKey);

        return await inner.UpdateAsync(entity, id);
    }
    public async Task<bool> DeleteAsync(T entity, int id)
    {
        var cachedKey = $"{typeof(T).Name}";

        cache.Remove(cachedKey);

        return await inner.DeleteAsync(entity, id);
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        var cachedKey = $"{typeof(T).Name}";

        cache.Remove(cachedKey);

        return await inner.DeleteRangeAsync(entities);
    }
    public async Task BeginTransaction()
    {
        await inner.BeginTransaction();
    }
    public async Task CommitTransaction()
    {
        await inner.CommitTransaction();
    }
    public async Task RollBack()
    {
        await inner.RollBack();
    }
    public async Task SaveChangesAsync()
    {
        await inner.SaveChangesAsync();
    }

}


