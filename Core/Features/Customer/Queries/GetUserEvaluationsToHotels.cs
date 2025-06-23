using Core.Features.Customers.Dtos;

namespace Core.Features.Customers.Queries;

public sealed record GetCustomerReviews(string UserId) : IRequest<Response<GetCustomerReviewsDto>>, ICachedQuery
{
    public string CachedId => $"Core-Users-Evaluations-{UserId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}