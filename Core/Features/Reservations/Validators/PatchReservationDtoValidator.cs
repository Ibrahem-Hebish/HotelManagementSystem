using Core.Features.Reservations.Dtos;

namespace Core.Features.Reservations.Validators;

public class PatchReservationDtoValidator : AbstractValidator<PatchReservationDto>
{
    public PatchReservationDtoValidator()
    {
        RuleFor(x => x.FoodServiceType)
           .IsInEnum().WithMessage("Invalid food service type. Allowed values are: Breakfast, HalfBoard, FullBoard.")
           .When(x => x.FoodServiceType.HasValue);

        RuleFor(x => x.ReservationStatus)
            .IsInEnum().WithMessage("Invalid reservation status. Allowed values are: Pending, Confirmed, Cancelled.")
            .When(x => x.ReservationStatus.HasValue);

        RuleFor(x => x.PaymentStatus)
            .IsInEnum().WithMessage("Invalid payment status. Allowed values are: Unpaid, Paid, Refunded.")
            .When(x => x.PaymentStatus.HasValue);
    }
}
