using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class CheckIfEmailExsistHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<CheckIfEmailExsist, Response<bool>>
{
    public async Task<Response<bool>> Handle(CheckIfEmailExsist request, CancellationToken CancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return Success(false, message: "This Email doesn't exsist");

        return Success(true, message: "This Email has already exsisted");
    }
}

