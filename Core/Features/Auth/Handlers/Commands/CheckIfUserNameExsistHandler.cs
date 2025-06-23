using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Handlers.Commands;

public class CheckIfUserNameExsistHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<CheckIfUsernameExsist, Response<bool>>
{
    public async Task<Response<bool>> Handle(CheckIfUsernameExsist request, CancellationToken CancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);

        if (user is null)
            return Success(false, message: "This Username doesn't exsist");

        return Success(true, message: "This Username has already exsisted");
    }
}

