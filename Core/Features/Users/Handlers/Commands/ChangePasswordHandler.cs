using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class ChangePasswordHandler(UserManager<User> userManager)
    : ResponseHandler,

    IRequestHandler<ChangePassword, Response<string>>
{
    public async Task<Response<string>> Handle(ChangePassword request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);

        if (user is null)
        {
            Log.Error("User with ID: {@UserId} not found", request.UserId);
            return NotFouned<string>("User not found");
        }

        var isValidPassword = await userManager.CheckPasswordAsync(user, request.OldPassword);

        if (!isValidPassword)
        {
            Log.Error("Invalid old password for user with ID: {@UserId}", request.UserId);
            return BadRequest<string>("Invalid old password");
        }

        var result = await userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            Log.Error("Failed to change password for user with ID: {@UserId}", request.UserId);
            return BadRequest<string>("Failed to change password");
        }

        Log.Information("Password changed successfully for user with ID: {@UserId}", request.UserId);

        return Success("Password changed successfully");

    }
}