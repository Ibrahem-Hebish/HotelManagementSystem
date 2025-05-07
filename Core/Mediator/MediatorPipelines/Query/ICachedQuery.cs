namespace Core.Mediator.MediatorPipelines.Query;

public interface ICachedQuery
{
    string CachedId { get; }
    TimeSpan? Expiration { get; }
}
