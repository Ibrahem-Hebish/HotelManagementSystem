using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsWithMaxPriceHandler(
          IRoomRepository repository,
                   IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetRoomsWithMaxPrice, Response<List<GetRoom>>>
{


    public async Task<Response<List<GetRoom>>> Handle(GetRoomsWithMaxPrice request, CancellationToken cancellationToken)
    {

        var spec = new GetWithMaxPriceSpecification(request.MaxPrice);

        var roomIncludeOptions = new RoomIncludeOptions();

        roomIncludeOptions.WithHotel().WithPhotos().WithFacilities();

        var rooms = await repository.Search(spec, roomIncludeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found with this max price");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
