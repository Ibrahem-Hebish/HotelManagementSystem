
namespace Core.Features.Reviews.Dtos;

public class GetReview
{

    public GetHotel Hotel { get; set; } = null!;

    public int Rate { get; set; }
    public string Comment { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
