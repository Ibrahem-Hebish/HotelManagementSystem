using Core.Features.Reservations.Dtos;
using Core.Features.Reservations.Queries;

namespace Core.Features.Reservations.Handlers.Queries;

public class GetHotelReservationsHandler(
    IReservationRepository reservationRepository,
       IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelReservations, Response<List<GetReservation>>>
{
    public async Task<Response<List<GetReservation>>> Handle(GetHotelReservations request, CancellationToken cancellationToken)
    {
        var spec = new GetHotelReservationSpecification(request.HotelId);

        var includeOptions = new ReservationIncludeOptions()
            .WithCustomer()
            .WithHotel()
            .WithRoom();

        var reservations = await reservationRepository.Search(spec, includeOptions, cancellationToken);

        if (reservations is null || reservations.Count == 0)
            return NotFouned<List<GetReservation>>("No reservations found for the specified hotel.");

        var reservationDtos = mapper.Map<List<GetReservation>>(reservations);

        return Success(reservationDtos);

    }
}
