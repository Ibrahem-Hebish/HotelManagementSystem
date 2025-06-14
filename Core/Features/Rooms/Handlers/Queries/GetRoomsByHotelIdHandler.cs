using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsByHotelIdHandler(
       IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsByHotelId, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetRoomsByHotelId request, CancellationToken cancellationToken)
    {
        var spec = new GetRoomsByHotelIdSpecification(request.HotelId);

        var options = new RoomIncludeOptions();

        options.WithHotel().WithPhotos();

        var rooms = await repository.Search(spec, options, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found for this hotel");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
