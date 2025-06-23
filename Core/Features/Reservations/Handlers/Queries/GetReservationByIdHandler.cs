using Core.Features.Reservations.Dtos;
using Core.Features.Reservations.Queries;

namespace Core.Features.Reservations.Handlers.Queries;

public class GetReservationByIdHandler(
    IReservationRepository reservationRepository,
       IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetReservationById, Response<GetReservation>>
{
    public async Task<Response<GetReservation>> Handle(GetReservationById request, CancellationToken cancellationToken)
    {
        var reservation = await reservationRepository.GetByIdAsync(request.Id, cancellationToken);

        if (reservation is null)
            return NotFouned<GetReservation>($"No reservation found with ID {request.Id}.");

        var reservationDto = mapper.Map<GetReservation>(reservation);

        return Success(reservationDto);
    }
}
