using Core.Mediator.MediatorPipelines.Query;

namespace Core.Facilities.Queries;

public sealed record GetFacilityById(int id) :
    IRequest<Response<Facilitiy>>, ICachedQuery
{
    public string CachedId => $"Core-Facilities-{id}";
    public TimeSpan? Expiration => null;

}
