namespace Core.Features.Rooms.Validators;

public class GetRoomsWithOffersValidator : AbstractValidator<GetRoomsByStatus>
{
    public GetRoomsWithOffersValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Room status can not be empty.")
            .NotNull()
            .WithMessage("Room status can not be null");
    }
}
