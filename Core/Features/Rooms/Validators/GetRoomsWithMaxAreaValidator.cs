namespace Core.Features.Rooms.Validators;

public class GetRoomsWithMaxAreaValidator : AbstractValidator<GetRoomsWithMaxArea>
{

    public GetRoomsWithMaxAreaValidator()
    {
        RuleFor(x => x.MaxArea)
            .GreaterThan(0)
            .WithMessage("Maximum area must be greater than 0.");
    }
}
