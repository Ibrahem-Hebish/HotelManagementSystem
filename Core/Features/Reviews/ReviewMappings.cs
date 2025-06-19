using Core.Features.Reviews.Dtos;

namespace Core.Features.Reviews;

public static class ReviewMappings
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<HotelReviews, GetReview>.NewConfig();
    }
}
