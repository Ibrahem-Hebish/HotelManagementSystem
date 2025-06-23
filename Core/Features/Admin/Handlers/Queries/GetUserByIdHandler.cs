using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUserByIdHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUserById, Response<GetUser>>
{
    public async Task<Response<GetUser>> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.id);

        if (user is null)
            return NotFouned<GetUser>();

        var userDto = user.Adapt<GetUser>();

        return Success(userDto);
    }
}
