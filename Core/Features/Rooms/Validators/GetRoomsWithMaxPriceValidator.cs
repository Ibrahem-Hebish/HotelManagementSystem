namespace Core.Features.Rooms.Validators;

public class GetRoomsWithMaxPriceValidator : AbstractValidator<GetRoomsWithMaxPrice>
{
    public GetRoomsWithMaxPriceValidator()
    {
        RuleFor(x => x.MaxPrice)
            .GreaterThan(0)
            .WithMessage("Maximum price must be greater than 0.");
    }
}
