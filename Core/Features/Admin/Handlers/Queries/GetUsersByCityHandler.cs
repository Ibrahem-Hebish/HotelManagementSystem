using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUsersByCityHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUsersByCity, Response<List<GetUser>>>
{
    public async Task<Response<List<GetUser>>> Handle(GetUsersByCity request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users
            .Where(u => EF.Functions.Like(u.City, $"%{request.City}%"))
            .ToListAsync(cancellationToken);

        if (users is null || users.Count == 0)
            return NotFouned<List<GetUser>>();

        var userDtos = users.Adapt<List<GetUser>>();

        return Success(userDtos);
    }
}