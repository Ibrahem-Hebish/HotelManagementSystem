using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsByStatusHandler(IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsByStatus, Response<List<GetRoom>>>
{

    public async Task<Response<List<GetRoom>>> Handle(GetRoomsByStatus request, CancellationToken cancellationToken)
    {

        var spec = new GetByRoomStatusSpecification(request.Status);

        var includeOptions = new RoomIncludeOptions();

        includeOptions.WithHotel().WithPhotos().WithFacilities();

        var rooms = await repository.Search(spec, includeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found for the specified type");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}