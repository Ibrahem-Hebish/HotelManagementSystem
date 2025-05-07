using Core.Mediator.MediatorPipelines.Query;

namespace Core.Facilities.Queries;

public sealed record GetFacilties :
    ICachedQuery, IRequest<Response<List<Facilitiy>>>
{
    public string CachedId => "Core-Facilties";

    public TimeSpan? Expiration => null;
}
