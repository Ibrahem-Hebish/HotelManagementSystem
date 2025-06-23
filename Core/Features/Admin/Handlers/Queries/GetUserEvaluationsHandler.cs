using Core.Features.Customers.Dtos;
using Core.Features.Customers.Queries;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUserEvaluationsHandler(
       IUserRepository userRepository,
       IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetCustomerReviews, Response<GetCustomerReviewsDto>>
{
    public async Task<Response<GetCustomerReviewsDto>> Handle(
               GetCustomerReviews request, CancellationToken cancellationToken)
    {
        try
        {
            var reviews = await userRepository.GetUserReviewsToHotels(
                      request.UserId, Tracking.AsNoTracking, cancellationToken);

            if (reviews is null || reviews.Count == 0)
                return NotFouned<GetCustomerReviewsDto>();

            var reviewsDtos = mapper.Map<List<GetReview>>(reviews);

            var userReviews = new GetCustomerReviewsDto
            {
                Id = request.UserId,
                GetReviews = reviewsDtos
            };

            return Success(userReviews);
        }
        catch
        {
            return BadRequest<GetCustomerReviewsDto>(
                               $"User with ID {request.UserId} not found");
        }
    }
}

