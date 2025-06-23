using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUserById(string id) : IRequest<Response<GetUser>>, IValidatorRequest, ICachedQuery
{
    public string CachedId => $"Core-Users-{id}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}
