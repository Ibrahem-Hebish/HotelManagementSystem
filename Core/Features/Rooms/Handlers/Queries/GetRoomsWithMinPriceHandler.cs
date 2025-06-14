using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsWithMinPriceHandler(
             IRoomRepository repository,
                               IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsWithMinPrice, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetRoomsWithMinPrice request, CancellationToken cancellationToken)
    {

        var spec = new GetWithMinPriceSpecification(request.MinPrice);

        var roomIncludeOptions = new RoomIncludeOptions();

        roomIncludeOptions.WithHotel().WithPhotos().WithFacilities();

        var rooms = await repository.Search(spec, roomIncludeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found with this min price");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
