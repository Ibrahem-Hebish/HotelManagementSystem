using Core.Features.Rooms.Queries;

namespace Core.Features.Rooms.Validators;

public class GetRoomsWithMinPriceValidator : AbstractValidator<GetRoomsWithMinPrice>
{
    public GetRoomsWithMinPriceValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThan(0)
            .WithMessage("Minimum price must be greater than 0.");
    }
}
