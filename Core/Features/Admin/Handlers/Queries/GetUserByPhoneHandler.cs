using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUserByPhoneHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUserByPhone, Response<GetUser>>
{
    public async Task<Response<GetUser>> Handle(GetUserByPhone request, CancellationToken cancellationToken)
    {
        var user = await userManager.Users
            .SingleOrDefaultAsync(u => u.PhoneNumber == request.Phone, cancellationToken);

        if (user is null)
            return NotFouned<GetUser>();

        var userDto = user.Adapt<GetUser>();

        return Success(userDto);
    }
}