using Core.Features.Reservations.Dtos;

namespace Core.Features.Reservations.Queries;

public sealed record GetHotelReservations(int HotelId) : IRequest<Response<List<GetReservation>>>, IValidatorRequest
{
}
