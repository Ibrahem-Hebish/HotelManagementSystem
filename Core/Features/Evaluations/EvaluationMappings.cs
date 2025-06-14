using Core.Features.Evaluations.Dtos;

namespace Core.Features.Evaluations;

public static class EvaluationMappings
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<HotelEvaluations, GetEvaluation>.NewConfig();
    }
}
