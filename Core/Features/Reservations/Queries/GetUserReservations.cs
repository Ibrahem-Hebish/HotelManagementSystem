using Core.Features.Reservations.Dtos;

namespace Core.Features.Reservations.Queries;

public sealed record GetCustomerReservations(string CustomerId) : IRequest<Response<List<GetReservation>>>, IValidatorRequest
{
}
