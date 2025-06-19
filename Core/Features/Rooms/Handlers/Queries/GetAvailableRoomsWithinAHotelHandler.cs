using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetAvailableRoomsWithinAHotelHandler(IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAvilableRoomsWithinHotel, Response<List<GetRoom>>>
{

    public async Task<Response<List<GetRoom>>> Handle(GetAvilableRoomsWithinHotel request, CancellationToken CancellationToken)
    {
        var spec = new GetAvailableRoomsInHotelSpecification(request.HotelId);

        var includeOptions = new RoomIncludeOptions();

        includeOptions.WithHotel().WithFacilities().WithPhotos();

        var rooms = await repository.Search(spec, includeOptions, CancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No available rooms found in the specified hotel");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);

    }
}
