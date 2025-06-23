namespace Core.Features.Rooms.Validators;

public class GetRoomsByAreaValidator : AbstractValidator<GetRoomsByArea>
{
    public GetRoomsByAreaValidator()
    {
        RuleFor(x => x.MinArea)
            .GreaterThan(0)
            .WithMessage("Minimum area must be greater than 0.");

        RuleFor(x => x.MaxArea)
            .GreaterThan(0)
            .WithMessage("Maximum area must be greater than 0.")
            .GreaterThan(x => x.MinArea)
            .WithMessage("Maximum area must be greater than minimum area.");
    }
}
