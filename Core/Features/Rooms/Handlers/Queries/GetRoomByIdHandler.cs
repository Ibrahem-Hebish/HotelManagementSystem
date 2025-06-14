using Core.Features.Rooms.Dtos;
using Core.Features.Rooms.Queries;

namespace Core.Features.Rooms.Handlers.Queries;

public class GetRoomByIdHandler(
    IRoomRepository repository,
    IMapper mapper)
        : ResponseHandler,
    IRequestHandler<GetRoomById, Response<GetRoom>>
{
    public async Task<Response<GetRoom>> Handle(GetRoomById request, CancellationToken cancellationToken)
    {
        var room = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (room is null)
        {
            return NotFouned<GetRoom>("No room found");
        }

        var roomDto = mapper.Map<GetRoom>(room);

        return Success(roomDto);
    }
}

