using Core.Features.Admin.Commands;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Commands;

public class CreateAdminHandler(
    UserManager<User> userManager,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork,
    IPublisher publisher,
    IMapper mapper)
    : ResponseHandler,
    IRequestHandler<CreateAdmin, Response<GetUser>>
{
    public async Task<Response<GetUser>> Handle(CreateAdmin request, CancellationToken cancellationToken)
    {
        using var transaction = unitOfWork.BeginTransaction();

        var isExsists = await userManager.FindByEmailAsync(request.Email!);

        if (isExsists is not null)
            return BadRequest<GetUser>("Email already exists");

        var user = request.Adapt<User>();

        try
        {
            Log.Information("Creating user with email: {@Email}", request.Email);

            var isCreated = await userManager.CreateAsync(user, request.Password);

            if (!isCreated.Succeeded)
            {
                Log.Error("Error while adding user {@error}", isCreated.Errors.FirstOrDefault()?.Description);

                return InternalServerError<GetUser>(isCreated.Errors.FirstOrDefault()?.Description!);

            }

            Log.Information("User with email: {@Email} created successfully", request.Email);

            var userRole = await userManager.AddToRoleAsync(user, "Admin");

            if (!userRole.Succeeded)
            {
                Log.Error("Error while adding user to role: {@Role}", userRole.Errors.FirstOrDefault()?.Description);

                return InternalServerError<GetUser>(userRole.Errors.FirstOrDefault()?.Description!);
            }

            await unitOfWork.CommitTransaction();

            var userDto = mapper.Map<GetUser>(user);

            await publisher.Publish(new UserCreatedNotification(user), cancellationToken);

            return Success(userDto, "Please, Check you email to confirm");
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Error while creating user");

            httpContextAccessor.HttpContext!.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            await unitOfWork.RollBack();

            return InternalServerError<GetUser>();
        }
    }
}

