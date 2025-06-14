using Core.Features.Facilities.Queries;

namespace Core.Features.Facilities.Handlers.Query;

public class GetFacilityByIdHandler(IFacilityRepository repository) :
    ResponseHandler,
    IRequestHandler<GetFacilityById, Response<Facilitiy>>

{
    public async Task<Response<Facilitiy>> Handle(GetFacilityById request, CancellationToken cancellationToken)
    {
        var facility = await repository.GetByIdAsync(request.id, Tracking.AsNoTracking, cancellationToken);

        if (facility is null)
            return NotFouned<Facilitiy>();

        return Success(facility);
    }
}
