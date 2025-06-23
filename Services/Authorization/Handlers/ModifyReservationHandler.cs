
using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class ModifyReservationHandler(
    IHttpContextAccessor httpContextAccessor,
    IReservationRepository reservationRepository,
    IHotelRepository hotelRepository
    ) : AuthorizationHandler<ModifyReservationPermission>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ModifyReservationPermission requirement)
    {
        var role = context.User.FindFirstValue(ClaimTypes.Role);

        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
            return;

        if (role is not null && (role == "Admin" || role == "Customer"))
            return;

        var reservationID = httpContextAccessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (reservationID is null)
            return;

        if (!int.TryParse(reservationID, out var reservationId))
            return;

        var reservation = await reservationRepository.GetByIdAsync(reservationId, CancellationToken.None);

        if (reservation is null)
            return;

        var hotel = await hotelRepository.GetByIdAsync(reservation.HotelId, CancellationToken.None);

        if (hotel is null)
            return;

        if (hotel.OwnerId == userId)
            context.Succeed(requirement);

        return;

    }
}