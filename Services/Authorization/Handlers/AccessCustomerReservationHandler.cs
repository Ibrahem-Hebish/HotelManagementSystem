using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class AccessCustomerReservationHandler(IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<AccessCustomerReservationPermission>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessCustomerReservationPermission requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var paramId = httpContextAccessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (userId == paramId)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
