
namespace Core.Features.Hotels.Handlers.Queries;

public class GetHotelRoomsHandler(
             IRoomRepository repository,
                               IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetRoomsInAHotel, Response<List<GetRoom>>>
{

    public async Task<Response<List<GetRoom>>> Handle(GetRoomsInAHotel request, CancellationToken CancellationToken)
    {
        var spec = new GetRoomsByHotelIdSpecification(request.HotelId);

        var includeOptions = new RoomIncludeOptions()
                                            .WithPhotos()
                                            .WithFacilities();

        var rooms = await repository.Search(spec, includeOptions, CancellationToken);

        if (rooms is null || rooms.Count == 0)
            return NotFouned<List<GetRoom>>();

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
