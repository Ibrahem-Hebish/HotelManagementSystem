using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsWithAreaRangeHandler(
             IRoomRepository repository,
                      IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsByArea, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetRoomsByArea request, CancellationToken cancellationToken)
    {
        var spec = new GetByAreaRangeSpecification(request.MinArea, request.MaxArea);

        var roomIncludeOptions = new RoomIncludeOptions();

        roomIncludeOptions.WithHotel().WithPhotos().WithFacilities();

        var rooms = await repository.Search(spec, roomIncludeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found in this area range");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
