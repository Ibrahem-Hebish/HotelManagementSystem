using Core.Features.Facilities.Queries;

namespace Core.Features.Facilities.Handlers.Query;

public class GetAllFacilitiesHandler(IFacilityRepository repository) :
    ResponseHandler,
    IRequestHandler<GetFacilties, Response<List<Facilitiy>>>

{
    public async Task<Response<List<Facilitiy>>> Handle(GetFacilties request, CancellationToken cancellationToken)
    {
        var facilities = await repository
                                 .GetAsync(Tracking.AsNoTracking, cancellationToken);

        if (facilities is null)
            return NotFouned<List<Facilitiy>>();

        return Success(facilities);
    }
}