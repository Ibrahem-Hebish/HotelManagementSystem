using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;

namespace Core.Features.Hotels.Handlers.Queries;

internal class GetHotelsHandler(
    IHotelRepository repository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllHotels, Response<List<GetHotel>>>
{
    public async Task<Response<List<GetHotel>>> Handle(GetAllHotels request, CancellationToken cancellationToken)
    {
        var hotels = await repository.GetAsync(Tracking.AsNoTracking, cancellationToken);

        if (hotels.Count == 0)
            return NotFouned<List<GetHotel>>("No hotels found");

        var result = mapper.Map<List<GetHotel>>(hotels);

        return Success(result);
    }
}
