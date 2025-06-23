namespace Core.Features.Reservations.Commands;

public sealed record PatchReservation(int Id, DateTime? CheckOutDate, FoodServiceType? foodServiceType
    , ReservationStatus? reservationStatus, PaymentStatus? paymentStatus)

    : IRequest<Response<bool>>, IValidatorRequest
{ }


