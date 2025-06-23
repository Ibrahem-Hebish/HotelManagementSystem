using Core.Features.Customers.Commands;

namespace Core.Features.Customers.Handlers.Commands;

public class PatchUserHandler(UserManager<User> userManager)
    : ResponseHandler,
    IRequestHandler<PatchUser, Response<string>>
{
    public async Task<Response<string>> Handle(PatchUser request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);

        if (user is null)
            return NotFouned<string>("User not found");



        if (!string.IsNullOrWhiteSpace(request.FirstName))
            user.FirstName = request.FirstName;

        if (!string.IsNullOrWhiteSpace(request.LastName))
            user.LastName = request.LastName;

        if (!string.IsNullOrWhiteSpace(request.UserName))
        {
            var isUserNameExists = await userManager.Users
                .AnyAsync(u => u.UserName == request.UserName && u.Id != request.Id, cancellationToken);

            if (isUserNameExists)
                return BadRequest<string>("Username already exists");

            user.UserName = request.UserName;

        }

        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var isEmailExists = await userManager.Users
           .AnyAsync(u => u.Email == request.Email && u.Id != request.Id, cancellationToken);

            if (isEmailExists)
                return BadRequest<string>("Email already exists");

            user.Email = request.Email;
        }

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            user.PhoneNumber = request.PhoneNumber;

        if (!string.IsNullOrWhiteSpace(request.Country))
            user.Country = request.Country;

        if (!string.IsNullOrWhiteSpace(request.City))
            user.City = request.City;

        if (request.BirthDate.HasValue)
            user.BirthDate = request.BirthDate.Value;

        if (request.Gender is UserGender.Female || request.Gender is UserGender.Male)
            user.Gender = (UserGender)request.Gender;

        var isUpdated = await userManager.UpdateAsync(user);

        if (!isUpdated.Succeeded)
        {
            Log.Error("Error while updating user: {@error}", isUpdated.Errors.FirstOrDefault()?.Description);
            return InternalServerError<string>(isUpdated.Errors.FirstOrDefault()?.Description!);
        }

        Log.Information("User with email: {@Email} updated successfully", user.Email);

        return Success(user.Id);
    }
}
