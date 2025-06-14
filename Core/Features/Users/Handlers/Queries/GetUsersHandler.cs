using Core.Features.Users.Dtos;
using Core.Features.Users.Queries;

namespace Core.Features.Users.Handlers.Queries;

public class GetUsersHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUsers, Response<List<GetUser>>>
{
    public async Task<Response<List<GetUser>>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken);

        if (users is null || users.Count == 0)
            return NotFouned<List<GetUser>>();

        var usersDtos = users.Adapt<List<GetUser>>();

        return Success(usersDtos);
    }
}

