using Core.Features.Evaluations.Dtos;

namespace Core.Features.Users.Dtos;

public class GetUserEvaluation
{
    public string Id { get; set; } = "";

    public List<GetEvaluation> GetEvaluations { get; set; } = [];
}
