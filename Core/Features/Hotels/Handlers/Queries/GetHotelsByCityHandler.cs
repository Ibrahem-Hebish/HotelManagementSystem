using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;
using Services.SpecificationPattern.HotelSpecifications;

namespace Core.Features.Hotels.Handlers.Queries;

internal class GetHotelsByCityHandler(
    IHotelRepository repository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelsByCity, Response<List<GetHotel>>>
{
    public async Task<Response<List<GetHotel>>> Handle(GetHotelsByCity request, CancellationToken cancellationToken)
    {
        var spec = new HotelCitySpecification(request.City);

        var hotelIncludeOptions = new HotelIncludeOptions();

        hotelIncludeOptions.WithRooms().WithEvaluations();

        var hotels = await repository.Search(spec, hotelIncludeOptions);

        if (hotels.Count == 0)
            return NotFouned<List<GetHotel>>("No hotels found");

        var hotelsDto = mapper.Map<List<GetHotel>>(hotels);

        return Success(hotelsDto);
    }
}
