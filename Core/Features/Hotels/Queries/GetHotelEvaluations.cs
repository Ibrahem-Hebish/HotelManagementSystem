using Core.Features.Reviews.Dtos;

namespace Core.Features.Hotels.Queries;

public sealed record GetHotelReviews(int HotelId) : IRequest<Response<List<GetReview>>>
{

}

