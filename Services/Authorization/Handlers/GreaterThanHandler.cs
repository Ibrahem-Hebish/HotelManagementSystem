namespace Services.Authorization.Handlers;

public class GreaterThanHandler : AuthorizationHandler<GreaterthanReqirment>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, GreaterthanReqirment requirement)
    {
        if (DateOnly.TryParse(
            context.User
            .FindFirst("DateOfBirth")?.Value
            , out DateOnly dateOfBirth))
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var age = GetUserAge(dateOfBirth, today);

            if (age > requirement.Age)
                context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

    private static int GetUserAge(DateOnly userDateOfBirth, DateOnly today)
    {
        var diffYear = today.Year - userDateOfBirth.Year;

        var diffMonth = today.Month - userDateOfBirth.Month;

        var diffDay = today.Day - userDateOfBirth.Day;

        if ((diffMonth <= 0 && diffDay < 0) || diffMonth < 0)
            diffYear--;

        return diffYear;
    }
}
