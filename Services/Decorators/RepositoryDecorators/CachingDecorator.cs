namespace Services.Decorators.RepositoryDecorators;

public class CachingDecorator<T>(
    IMemoryCache cache,
    IRepository<T> inner)

    : IRepository<T> where T : class, IEntity
{
    public async Task<List<T>> GetAsync(Tracking tracking)
    {
        var cachedKey = $"{typeof(T).Name}";

        if (!cache.TryGetValue(cachedKey, out List<T>? result))
        {
            var entities = await inner.GetAsync(tracking);

            if (entities is not null && entities.Count > 0)
                cache.Set(cachedKey, entities, Set_memoryCacheOptions());

            return entities!;
        }

        return result!;
    }
    public async Task<T> GetByIdAsync(int id, Tracking tracking,
                                 CancellationToken cancellationToken)
    {
        var cachedKey = $"{typeof(T).Name}-{id}";

        if (!cache.TryGetValue(cachedKey, out T? result))
        {
            var entity = await inner.GetByIdAsync(id, tracking, cancellationToken);

            if (entity is not null)
                cache.Set(cachedKey, entity, Set_memoryCacheOptions());

            return entity!;
        }

        return result!;
    }
    public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        var cachedKey = $"{typeof(T).Name}";

        try
        {
            var isCreated = await inner.CreateAsync(entity, cancellationToken);

            cache.Remove(cachedKey);

            return isCreated;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while creating entity");
            return false;
        }

    }
    public async Task<bool> UpdateAsync(T entity, int id)
    {
        var typeCachedKey = $"{typeof(T).Name}";
        var entityCachedKey = $"{typeof(T).Name}-{id}";

        try
        {
            var isUpdated = await inner.UpdateAsync(entity, id);

            cache.Remove(typeCachedKey);
            cache.Remove(entityCachedKey);

            return isUpdated;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while updating entity");

            return false;
        }
    }
    public async Task<bool> DeleteAsync(T entity, int id)
    {
        var typeCachedKey = $"{typeof(T).Name}";
        var entityCachedKey = $"{typeof(T).Name}-{id}";

        try
        {
            var isDeleted = await inner.DeleteAsync(entity, id);

            cache.Remove(typeCachedKey);
            cache.Remove(entityCachedKey);

            return isDeleted;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while deleting entity");

            return false;
        }
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        var typeCachedKey = $"{typeof(T).Name}";

        try
        {
            var isDeleted = await inner.DeleteRangeAsync(entities);

            cache.Remove(typeCachedKey);

            return isDeleted;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while deleting entities");

            return false;
        }
    }
    protected static MemoryCacheEntryOptions Set_memoryCacheOptions()
    {
        var options = new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2),
            SlidingExpiration = TimeSpan.FromMinutes(1),
            Priority = CacheItemPriority.Normal,
        };

        return options;
    }
}


