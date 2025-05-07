namespace Services.Decorators.RepositoryDecorators;

public class LoggingDecorator<T>(
    IRepository<T> inner)

    : IRepository<T> where T : class, IEntity
{
    public async Task<T> GetByIdAsync(int id, Tracking tracking,
                                       CancellationToken cancellationToken)
    {
        Log.Information("Logging from service layer : Getting {@type} with id {@id}", typeof(T).Name, id);

        var entity = await inner.GetByIdAsync(id, tracking, cancellationToken);

        if (entity is null)
        {
            Log.Information("Logging from service layer : There is no {@type} with id {@id}", typeof(T).Name, id);

            return entity!;
        }

        Log.Information("Logging from service layer : Got {@type} with id {@id}", typeof(T).Name, id);

        return entity!;
    }
    public async Task<List<T>> GetAsync(Tracking tracking)
    {
        Log.Information("Logging from service layer : Getting {@EntityType}s", typeof(T).Name);

        var entities = await inner.GetAsync(tracking);

        if (entities == null || entities.Count == 0)
        {
            Log.Information("Logging from service layer : {@EntityType}s is empty", typeof(T).Name);

            return entities!;
        }

        Log.Information("Logging from service layer : Got {@EntityType}s", typeof(T).Name);

        return entities!;
    }
    public async Task<bool> UpdateAsync(T entity, int id)
    {
        Log.Information("Logging from service layer : Update {@EntityType} with id {@id}", nameof(entity), id);

        var isUpdated = await inner.UpdateAsync(entity, id);

        if (isUpdated)
        {
            Log.Information("Logging from service layer : Updated {@EntityType} with id {@id}", nameof(entity), id);

            return isUpdated;
        }

        Log.Information("Logging from service layer : Update {@EntityType} with id {@id} failed", nameof(entity), id);

        return isUpdated;
    }
    public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        Log.Information("Logging from service layer : Creating {@EntityType} {@Entity}", typeof(T).Name, entity.ToString());

        var isCreated = await inner.CreateAsync(entity, cancellationToken);

        if (!isCreated)
        {
            Log.Information("Logging from service layer : Creating new {@EntityType} failed", typeof(T).Name);

            return isCreated;
        }

        Log.Information("Logging from service layer : Created {@EntityType} succeded", typeof(T).Name);

        return isCreated;
    }
    public async Task<bool> DeleteAsync(T entity, int id)
    {
        Log.Information("Logging from service layer : Deleting {@EntityType} with id {@id}", typeof(T).Name, id);

        var isDeleted = await inner.DeleteAsync(entity, id);

        if (!isDeleted)
        {
            Log.Information("Logging from service layer : Deleting {@EntityType} with id {@id} failed", typeof(T).Name, id);

            return isDeleted;
        }

        Log.Information("Logging from service layer : {@EntityType} with id {@id} was deleted", typeof(T).Name, id);

        return isDeleted;
    }
    public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
    {
        Log.Information("Logging from service layer : Deleting {@EntityType} {@Entity}", typeof(T).Name, entities);

        var isDeleted = await inner.DeleteRangeAsync(entities);

        if (!isDeleted)
        {
            Log.Information("Logging from service layer : Deleting {@EntityType} failed", typeof(T).Name);

            return isDeleted;
        }

        Log.Information("Logging from service layer : {@EntityType}s were deleted", typeof(T).Name);

        return isDeleted;
    }

}


