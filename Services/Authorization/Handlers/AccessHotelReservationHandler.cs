using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class AccessHotelReservationHandler(
    IHttpContextAccessor httpContextAccessor,
    AppDbContext dbContext)
    : AuthorizationHandler<AccessHotelReservationPermission>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessHotelReservationPermission requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var role = context.User.FindFirstValue(ClaimTypes.Role);
        var hotelIdStr = httpContextAccessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(hotelIdStr))
            return Task.CompletedTask;

        if (!int.TryParse(hotelIdStr, out var hotelId))
            return Task.CompletedTask;

        if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        if (role.Equals("vendor", StringComparison.OrdinalIgnoreCase))
        {
            var isOwner = dbContext.Hotels.Any(h => h.OwnerId == userId && h.Id == hotelId);
            if (isOwner)
                context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
