using Core.Features.Admin.Queries;
using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Handlers.Queries;

public class GetUsersByCountryHandler(UserManager<User> userManager) :
    ResponseHandler,
    IRequestHandler<GetUsersByCountry, Response<List<GetUser>>>
{
    public async Task<Response<List<GetUser>>> Handle(GetUsersByCountry request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users
            .Where(u => EF.Functions.Like(u.Country, $"%{request.Country}%"))
            .ToListAsync(cancellationToken);

        if (users is null || users.Count == 0)
            return NotFouned<List<GetUser>>();

        var userDtos = users.Adapt<List<GetUser>>();

        return Success(userDtos);
    }
}
