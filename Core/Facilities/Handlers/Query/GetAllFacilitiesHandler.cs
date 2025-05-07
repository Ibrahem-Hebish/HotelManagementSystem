namespace Core.Facilities.Handlers.Query;

public class GetAllFacilitiesHandler(IRepository<Facilitiy> repository) :
    ResponseHandler,
    IRequestHandler<GetFacilties, Response<List<Facilitiy>>>

{
    public async Task<Response<List<Facilitiy>>> Handle(GetFacilties request, CancellationToken cancellationToken)
    {
        var facilities = await repository
                                 .GetAsync(Tracking.AsNoTracking);

        if (facilities is null)
            return NotFouned<List<Facilitiy>>();

        return Success(facilities);
    }
}