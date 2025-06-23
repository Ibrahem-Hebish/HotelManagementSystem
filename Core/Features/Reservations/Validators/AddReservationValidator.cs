using Core.Features.Reservations.Commands;

namespace Core.Features.Reservations.Validators;

public class AddReservationValidator : AbstractValidator<AddReservation>
{
    public AddReservationValidator()
    {
        RuleFor(x => x.HotelId)
            .GreaterThan(0).WithMessage("Hotel ID must be greater than 0.");

        RuleFor(x => x.RoomId)
            .GreaterThan(0).WithMessage("Room ID must be greater than 0.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(x => x.FoodServiceType)
            .IsInEnum().WithMessage("Invalid food service type. Allowed values are: Breakfast, HalfBoard, FullBoard.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid reservation status. Allowed values are: Pending, Confirmed, Cancelled.");

        RuleFor(x => x.PaymentStatus)
            .IsInEnum().WithMessage("Invalid payment status. Allowed values are: Unpaid, Paid, Refunded.");

        RuleFor(x => x.CheckInDate)
            .NotEmpty().WithMessage("Check-in date is required.")
            .LessThanOrEqualTo(x => x.CheckOutDate).WithMessage("Check-in date must be before or equal to check-out date.");
    }
}
