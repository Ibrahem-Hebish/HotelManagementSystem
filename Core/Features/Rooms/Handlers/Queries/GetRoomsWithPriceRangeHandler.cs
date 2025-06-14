using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsWithPriceRangeHandler(
       IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsByPrice, Response<List<GetRoom>>>
{

    public async Task<Response<List<GetRoom>>> Handle(GetRoomsByPrice request, CancellationToken cancellationToken)
    {
        var spec = new GetWithPriceRangeSpecification(request.MinPrice, request.MaxPrice);

        var roomIncludeOptions = new RoomIncludeOptions();

        roomIncludeOptions.WithHotel().WithPhotos().WithFacilities();

        var rooms = await repository.Search(spec, roomIncludeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found in this price range");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
