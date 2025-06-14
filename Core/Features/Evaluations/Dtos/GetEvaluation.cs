using Core.Features.Hotels.Dto;

namespace Core.Features.Evaluations.Dtos;

public class GetEvaluation
{

    public GetHotel Hotel { get; set; } = null!;

    public int Rate { get; set; }
    public string Comment { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
