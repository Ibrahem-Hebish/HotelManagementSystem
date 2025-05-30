﻿namespace Core.Users.Handlers.Commands;

public class CreateAdminHandler(UserManager<User> userManager,
    IAuthenticationService authenticationService,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<CreateAdmin, Response<UserToken>>
{
    public async Task<Response<UserToken>> Handle(CreateAdmin request, CancellationToken cancellationToken)
    {
        using var transaction = unitOfWork.BeginTransaction();

        var isExsists = await userManager.FindByEmailAsync(request.Email!);

        if (isExsists is not null)
            return BadRequest<UserToken>("Email already exists");

        var user = request.Adapt<User>();

        try
        {
            Log.Information("Creating user with email: {@Email}", request.Email);

            var isCreated = await userManager.CreateAsync(user, request.Password);

            if (!isCreated.Succeeded)
            {
                Log.Error("Error while adding user {@error}", isCreated.Errors.FirstOrDefault()?.Description);

                return InternalServerError<UserToken>(isCreated.Errors.FirstOrDefault()?.Description!);

            }

            Log.Information("User with email: {@Email} created successfully", request.Email);

            var userRole = await userManager.AddToRoleAsync(user, "Admin");

            if (!userRole.Succeeded)
            {
                Log.Error("Error while adding user to role: {@Role}", userRole.Errors.FirstOrDefault()?.Description);

                return InternalServerError<UserToken>(userRole.Errors.FirstOrDefault()?.Description!);
            }

            var userToken = await authenticationService.CreateToken(user, DateTime.UtcNow.AddDays(7));

            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransaction();

            return Success(userToken);
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Error while creating user");

            httpContextAccessor.HttpContext!.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            await unitOfWork.RollBack();

            return InternalServerError<UserToken>();
        }
    }
}

