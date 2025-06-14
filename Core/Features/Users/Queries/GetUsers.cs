using Core.Features.Users.Dtos;

namespace Core.Features.Users.Queries;

public sealed record GetUsers() : IRequest<Response<List<GetUser>>>, ICachedQuery
{
    public string CachedId => $"Core-Users";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}
