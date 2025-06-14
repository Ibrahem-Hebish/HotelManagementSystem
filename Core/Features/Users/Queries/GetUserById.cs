using Core.Features.Users.Dtos;
using Core.Mediator.MediatorPipelines.Query;

namespace Core.Features.Users.Queries;

public sealed record GetUserById(string id) : IRequest<Response<GetUser>>, IValidatorRequest, ICachedQuery
{
    public string CachedId => $"Core-Users-{id}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}
