namespace Core.Features.Rooms.Validators;

public class GetRoomsWithMinAreaValidator : AbstractValidator<GetRoomsWithMinArea>
{
    public GetRoomsWithMinAreaValidator()
    {
        RuleFor(x => x.MinArea)
            .GreaterThan(0)
            .WithMessage("Minimum area must be greater than 0.");
    }
}
