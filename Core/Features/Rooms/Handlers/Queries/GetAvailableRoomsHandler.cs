using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetAvailableRoomsHandler(
       IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAvilableRooms, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetAvilableRooms request, CancellationToken CancellationToken)
    {
        var spec = new GetAvailableRoomsSpecification();

        var includeOptions = new RoomIncludeOptions();

        includeOptions
            .WithHotel()
            .WithFacilities()
            .WithPhotos()
            .AsSplitQuery();

        var rooms = await repository.Search(spec, includeOptions, CancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No available rooms found");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
