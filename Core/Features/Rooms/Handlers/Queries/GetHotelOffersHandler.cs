using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetHotelOffersHandler(
       IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
    IRequestHandler<GetHotelOffers, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetHotelOffers request, CancellationToken cancellationToken)
    {
        var spec = new GetHotelOffersSpecification(request.HotelId);

        var hotelIncludeOptions = new RoomIncludeOptions();

        hotelIncludeOptions.WithHotel().WithFacilities().WithPhotos();

        var rooms = await repository.Search(spec, hotelIncludeOptions, cancellationToken);

        if (rooms is null || rooms.Count == 0)
            return NotFouned<List<GetRoom>>("No rooms found for this hotel");

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}