namespace Core.Mediator.MediatorPipelines.Commands;

public class CommandCachingPipeline<TRequest, TResponse>(IMemoryCache cache) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
    where TResponse : IResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next(cancellationToken);

        if (result.IsSuccess)
            cache.Remove(request.CachedId);

        return result;
    }
}

