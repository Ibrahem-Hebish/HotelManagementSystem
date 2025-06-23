using Core.Features.Reservations.Dtos;

namespace Core.Features.Reservations.Queries;

public sealed record GetReservationById(int Id) : IRequest<Response<GetReservation>>, IValidatorRequest
{
}
