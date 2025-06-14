using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class ReseatPasswordHandler(UserManager<User> userManager)
        : ResponseHandler,
          IRequestHandler<ReseatPassword, Response<string>>
{
    public async Task<Response<string>> Handle(ReseatPassword request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            Log.Error("User with Email: {@UserId} not found", request.Email);
            return NotFouned<string>("User not found");
        }

        var code = user.Code;

        if (string.IsNullOrWhiteSpace(code))
        {
            Log.Error("No code found for reseating password for user with Email: {@UserId}", request.Email);
            return BadRequest<string>("No code found");
        }

        var resetPasswordResult = await userManager.ResetPasswordAsync(user, code, request.NewPassword);

        if (!resetPasswordResult.Succeeded)
        {
            Log.Error("Failed to reseat password for user with Email: {@UserId}", request.Email);
            return BadRequest<string>("Failed to reseat password");
        }

        Log.Information("Password reseated successfully for user with Email: {@UserId}", request.Email);

        return Success("Password reseated successfully");

    }
}
