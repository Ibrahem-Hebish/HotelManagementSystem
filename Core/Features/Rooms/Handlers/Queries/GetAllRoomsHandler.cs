using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetAllRoomsHandler(
    IRoomRepository repository,
    IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAllRooms, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetAllRooms request, CancellationToken cancellationToken)
    {
        var rooms = await repository.GetAsync(Tracking.AsNoTracking, cancellationToken);


        if (rooms is null)
        {
            return NotFouned<List<GetRoom>>("No rooms found");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}

public class GetAvailableRoomsHandler(
       IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAvilableRooms, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetAvilableRooms request, CancellationToken cancellationToken)
    {
        var spec = new GetAvailableRoomsSpecification();

        var includeOptions = new RoomIncludeOptions();

        includeOptions.WithHotel().WithFacilities().WithPhotos();

        var rooms = await repository.Search(spec, includeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No available rooms found");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}

public class GetAvailableRoomsWithinAHotelHandler(IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetAvilableRoomsWithinHotel, Response<List<GetRoom>>>
{

    public async Task<Response<List<GetRoom>>> Handle(GetAvilableRoomsWithinHotel request, CancellationToken cancellationToken)
    {
        var spec = new GetAvailableRoomsInHotelSpecification(request.HotelId);

        var includeOptions = new RoomIncludeOptions();

        includeOptions.WithHotel().WithFacilities().WithPhotos();

        var rooms = await repository.Search(spec, includeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No available rooms found in the specified hotel");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);

    }
}
