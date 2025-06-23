using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUserByEmailHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUserByEmail, Response<GetUser>>
{
    public async Task<Response<GetUser>> Handle(GetUserByEmail request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return NotFouned<GetUser>();

        var userDto = user.Adapt<GetUser>();

        return Success(userDto);
    }
}

