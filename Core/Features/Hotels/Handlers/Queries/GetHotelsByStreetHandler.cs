namespace Core.Features.Hotels.Handlers.Queries;

public class GetHotelsByStreetHandler(
       IHotelRepository repository,
          IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelsInAStreet, Response<List<GetHotel>>>
{

    public async Task<Response<List<GetHotel>>> Handle(GetHotelsInAStreet request, CancellationToken CancellationToken)
    {
        var spec = new HotelStreetSpecification(request.Street);

        var includeOptions = new HotelIncludeOptions()
                                            .WithRooms();

        var hotels = await repository.Search(spec, includeOptions);

        if (hotels is null || hotels.Count == 0)
            return NotFouned<List<GetHotel>>();

        var hotelDtos = mapper.Map<List<GetHotel>>(hotels);

        return Success(hotelDtos);

    }
}
