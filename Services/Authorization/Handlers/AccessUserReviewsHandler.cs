using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class AccessUserReviewsHandler(
    IHttpContextAccessor httpContextAccessor)

 : AuthorizationHandler<AccessReviewsPermission>
{
    protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context, AccessReviewsPermission requirement)
    {
        var userId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var role = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var userIdParam = httpContextAccessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (userId is null || userIdParam is null)
            return Task.CompletedTask;

        if (userId == userIdParam || role == "Admin")
            context.Succeed(requirement);


        return Task.CompletedTask;
    }
}
