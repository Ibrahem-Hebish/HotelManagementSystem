using Microsoft.AspNetCore.Http;

namespace Services.Authorization.Handlers;

public class AccessCustomerDataHandler(
    IHttpContextAccessor accessor,
    AppDbContext dbContext)

    : AuthorizationHandler<AccessCustomerDataPermission>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessCustomerDataPermission requirement)
    {
        var vendorId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userIdParam = accessor.HttpContext?.Request.RouteValues["id"]?.ToString();

        if (vendorId is null || userIdParam is null)
            return;

        var vendorHotels = await dbContext.Hotels.Where(h => h.OwnerId == vendorId)
            .Select(h => h.Id)
            .ToListAsync();

        var customer = await dbContext.Customers.FindAsync(userIdParam);

        if (customer is null)
            return;

        var customerHotels = await dbContext.HotelCustomers
            .Where(hc => hc.CustomerId == customer.Id && vendorHotels.Contains(hc.HotelId))
            .Select(hc => hc.HotelId)
            .ToListAsync();

        if (customerHotels.Count != 0)
            context.Succeed(requirement);

        return;
    }
}
