using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class AccessReservationByIdHandler(
       IHttpContextAccessor accessor,
          AppDbContext dbContext)

    : AuthorizationHandler<AccessReservationByIdPermission>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessReservationByIdPermission requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var role = context.User.FindFirstValue(ClaimTypes.Role);

        var reservationIdParam = accessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (userId is null || reservationIdParam is null)
            return;

        if (!int.TryParse(reservationIdParam, out var reservationId))
            return;

        var reservation = await dbContext.Reservations.FindAsync(reservationId);

        if (reservation is null)
            return;

        if (reservation.CustomerId == userId || (role is not null && role == "Admin"))
            context.Succeed(requirement);

        var hotel = await dbContext.Hotels.FindAsync(reservation.HotelId);

        if (hotel?.OwnerId == userId)
            context.Succeed(requirement);

        return;
    }
}