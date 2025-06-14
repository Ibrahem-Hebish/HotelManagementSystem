using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;
using Services.SpecificationPattern.HotelSpecifications;

namespace Core.Features.Hotels.Handlers.Queries;

internal class GetHotelsByCountryHandler(
    IHotelRepository repository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelsByCountry, Response<List<GetHotel>>>
{
    public async Task<Response<List<GetHotel>>> Handle(GetHotelsByCountry request, CancellationToken cancellationToken)
    {
        var spec = new HotelCountrySpecification(request.Country);

        var hotelIncludeOptions = new HotelIncludeOptions();

        hotelIncludeOptions.WithRooms().WithEvaluations();

        var hotels = await repository.Search(spec, hotelIncludeOptions);

        if (hotels is null || hotels.Count == 0)
            return NotFouned<List<GetHotel>>("Hotels is empty");

        var result = mapper.Map<List<GetHotel>>(hotels);

        return Success(result);
    }
}