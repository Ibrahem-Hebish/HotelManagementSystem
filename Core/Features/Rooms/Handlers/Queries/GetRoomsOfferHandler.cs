using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;
using Services.SpecificationPattern.RoomSpecifications;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomsOfferHandler(IRoomRepository repository,
          IMapper mapper)
    : ResponseHandler,
      IRequestHandler<GetRoomsWithOffer, Response<List<GetRoom>>>
{
    public async Task<Response<List<GetRoom>>> Handle(GetRoomsWithOffer request, CancellationToken cancellationToken)
    {

        var spec = new GetRoomsOffersSpecification();

        var options = new RoomIncludeOptions();

        options.WithHotel().WithPhotos();

        var rooms = await repository.Search(spec, options, cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return NotFouned<List<GetRoom>>("No rooms found for this offer");
        }

        var roomDtos = mapper.Map<List<GetRoom>>(rooms);

        return Success(roomDtos);
    }
}
