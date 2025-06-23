
namespace Core.Features.Rooms.Validators;

public class GetHotelRoomsValidator : AbstractValidator<GetRoomsByHotelId>
{
    public GetHotelRoomsValidator()
    {
        RuleFor(x => x.HotelId)
            .GreaterThan(0)
            .WithMessage("Hotel ID must be greater than 0.");
    }
}
