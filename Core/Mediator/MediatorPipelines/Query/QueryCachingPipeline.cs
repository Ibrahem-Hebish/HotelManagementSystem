namespace Core.Mediator.MediatorPipelines.Query;

public class QueryCachingPipeline<TRequest, TResponse>(IMemoryCache cache) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    where TResponse : IResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!cache.TryGetValue(request.CachedId, out TResponse? response))
        {
            Log.Information("Logging from Core layer : Cache miss for {@RequestType}", typeof(TRequest).Name);

            var result = await next(cancellationToken);

            if (result.IsSuccess)
            {
                cache.Set(request.CachedId, result, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = request.Expiration ?? TimeSpan.FromMinutes(5)
                });
            }

            return result;
        }
        Log.Information("Logging from Core layer : Cache hit for {@RequestType}", typeof(TRequest).Name);

        return response!;
    }
}

