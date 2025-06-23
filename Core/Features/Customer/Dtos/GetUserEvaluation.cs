namespace Core.Features.Customers.Dtos;

public class GetCustomerReviewsDto
{
    public string Id { get; set; } = "";

    public List<GetReview> GetReviews { get; set; } = [];
}
