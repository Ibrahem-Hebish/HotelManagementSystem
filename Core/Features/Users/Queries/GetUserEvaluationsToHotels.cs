using Core.Features.Users.Dtos;

namespace Core.Features.Users.Queries;

public sealed record GetUserEvaluationsToHotels(string UserId) : IRequest<Response<GetUserEvaluation>>, ICachedQuery
{
    public string CachedId => $"Core-Users-Evaluations-{UserId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}