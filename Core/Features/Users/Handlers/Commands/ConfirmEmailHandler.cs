using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class ConfirmEmailHandler(UserManager<User> userManager,
          IHttpContextAccessor httpContextAccessor)
    : ResponseHandler,
    IRequestHandler<ConfirmEmail, Response<bool>>
{
    public async Task<Response<bool>> Handle(ConfirmEmail request, CancellationToken cancellationToken)
    {
        try
        {
            Log.Information("Confirming email for user with email: {@Email}", request.Email);

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                Log.Error("User with email: {@Email} not found", request.Email);
                return BadRequest<bool>("User not found");
            }

            var result = await userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
            {
                Log.Error("Error while confirming email for user with email: {@Email}", request.Email);
                return BadRequest<bool>("Invalid token");
            }

            Log.Information("Email for user with email: {@Email} confirmed successfully", request.Email);

            return Success(true, message: "Congratulaion, You can sign in now");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while confirming email for user with email: {@Email}", request.Email);

            httpContextAccessor.HttpContext!.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            return InternalServerError<bool>();
        }
    }
}
