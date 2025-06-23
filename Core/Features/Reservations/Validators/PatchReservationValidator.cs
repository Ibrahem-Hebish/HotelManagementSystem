using Core.Features.Reservations.Commands;

namespace Core.Features.Reservations.Validators;

public class PatchReservationValidator : AbstractValidator<PatchReservation>
{
    public PatchReservationValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Reservation ID must be greater than 0.");

        RuleFor(x => x.foodServiceType)
            .IsInEnum().WithMessage("Invalid food service type. Allowed values are: Breakfast, HalfBoard, FullBoard.")
            .When(x => x.foodServiceType.HasValue);

        RuleFor(x => x.reservationStatus)
            .IsInEnum().WithMessage("Invalid reservation status. Allowed values are: Pending, Confirmed, Cancelled.")
            .When(x => x.reservationStatus.HasValue);

        RuleFor(x => x.paymentStatus)
            .IsInEnum().WithMessage("Invalid payment status. Allowed values are: Unpaid, Paid, Refunded.")
            .When(x => x.paymentStatus.HasValue);
    }
}
