namespace Core.Rooms.Handlers.Queries;

public class GetAllRoomsHandler(
    IRoomRepository repository,
    IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAllRooms, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetAllRooms request, CancellationToken cancellationToken)
    {
        var rooms = await repository.GetAsync(Tracking.AsNoTracking);


        if (rooms is null)
        {
            return NotFouned<List<GetRoom>>("No rooms found");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
