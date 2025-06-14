using Core.Features.Evaluations.Dtos;
using Core.Features.Users.Dtos;
using Core.Features.Users.Queries;

namespace Core.Features.Users.Handlers.Queries;

public class GetUserEvaluationsHandler(
       IUserRepository userRepository,
       IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetUserEvaluationsToHotels, Response<GetUserEvaluation>>
{
    public async Task<Response<GetUserEvaluation>> Handle(
               GetUserEvaluationsToHotels request, CancellationToken cancellationToken)
    {
        try
        {
            var evaluations = await userRepository.GetUserEvaluationsToHotels(
                      request.UserId, Tracking.AsNoTracking, cancellationToken);

            if (evaluations is null || evaluations.Count == 0)
                return NotFouned<GetUserEvaluation>();

            var evaluationsDtos = mapper.Map<List<GetEvaluation>>(evaluations);

            var userEvaluation = new GetUserEvaluation
            {
                Id = request.UserId,
                GetEvaluations = evaluationsDtos
            };

            return Success(userEvaluation);
        }
        catch
        {
            return BadRequest<GetUserEvaluation>(
                               $"User with ID {request.UserId} not found");
        }
    }
}

