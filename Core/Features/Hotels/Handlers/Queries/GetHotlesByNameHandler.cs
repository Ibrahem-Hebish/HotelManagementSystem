using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;
using Services.SpecificationPattern.HotelSpecifications;

namespace Core.Features.Hotels.Handlers.Queries;

public class GetHotlesByNameHandler(
          IHotelRepository repository,
                   IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelsByName, Response<List<GetHotel>>>
{

    public async Task<Response<List<GetHotel>>> Handle(GetHotelsByName request, CancellationToken CancellationToken)
    {
        var spec = new HotelNameSpecification(request.Name);

        var includeOptions = new HotelIncludeOptions()
                                            .WithRooms();

        var hotels = await repository.Search(spec, includeOptions);

        if (hotels is null || hotels.Count == 0)
            return NotFouned<List<GetHotel>>();

        var hotelDtos = mapper.Map<List<GetHotel>>(hotels);

        return Success(hotelDtos);
    }
}
