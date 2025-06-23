namespace Core.Features.Rooms.Validators;

public class GetRoomsWithPriceInRangeValidator : AbstractValidator<GetRoomsByPrice>
{
    public GetRoomsWithPriceInRangeValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThan(0)
            .WithMessage("Minimum price must be greater than 0.");

        RuleFor(x => x.MaxPrice)
            .GreaterThan(0)
            .WithMessage("Maximum price must be greater than 0.")
            .GreaterThan(x => x.MinPrice)
            .WithMessage("Maximum price must be greater than minimum price.");
    }
}
