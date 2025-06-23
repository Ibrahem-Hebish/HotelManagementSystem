using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUserByUserNameHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUserByUsername, Response<GetUser>>
{
    public async Task<Response<GetUser>> Handle(GetUserByUsername request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);

        if (user is null)
            return NotFouned<GetUser>();

        var userDto = user.Adapt<GetUser>();

        return Success(userDto);
    }
}