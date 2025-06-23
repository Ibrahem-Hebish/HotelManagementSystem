using Core.Features.Admin.Commands;

namespace Core.Features.Admin.Handlers.Commands;

public class DeleteUserHandler(
       UserManager<User> userManager,
       IUnitOfWork unitOfWork,
       IHttpContextAccessor httpContextAccessor)

    : ResponseHandler,
    IRequestHandler<DeleteUser, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        using var transaction = unitOfWork.BeginTransaction();

        var user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null)
            return NotFouned<bool>("User not found");

       var roles = await userManager.GetRolesAsync(user);

        if (roles is null || !roles.Any())
            return NotFouned<bool>("User role not found");

       if(roles.Any(r => r.ToLower() == "admin"))
            return BadRequest<bool>("You can't delete admin user");

        try
        {
            Log.Information("Deleting user with ID: {@UserId}", request.UserId);

            var isDeleted = await userManager.DeleteAsync(user);

            if (!isDeleted.Succeeded)
            {
                Log.Error("Error while deleting user: {@error}", isDeleted.Errors.FirstOrDefault()?.Description);
                return InternalServerError<bool>(isDeleted.Errors.FirstOrDefault()?.Description!);
            }

            Log.Information("User with ID: {@UserId} deleted successfully", request.UserId);

            await unitOfWork.CommitTransaction();

            return Success(true, "User deleted successfully");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while deleting user with ID: {@UserId}", request.UserId);

            httpContextAccessor.HttpContext!.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            await unitOfWork.RollBack();

            return InternalServerError<bool>();
        }
    }
}

