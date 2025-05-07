namespace Core.Users.Handlers.Commands;

public class SignInHandler(UserManager<User> userManager,
    IAuthenticationService authenticationService,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<SignIn, Response<UserToken>>
{
    public async Task<Response<UserToken>> Handle(SignIn request, CancellationToken cancellationToken)
    {
        Log.Information("Signing in user with email: {@Email}", request.Email);

        var user = await userManager.FindByEmailAsync(request.Email!);

        if (user is null)
        {
            Log.Error("User with email: {@Email} not found", request.Email);

            return BadRequest<UserToken>("Invalid Credintials");
        }

        var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password);

        if (!isValidPassword)
        {
            Log.Error("Invalid password for user with email: {@Email}", request.Email);

            return BadRequest<UserToken>("Invalid Credintials");
        }

        var userToken = await authenticationService.CreateToken(user, DateTime.UtcNow.AddMonths(3));

        await unitOfWork.SaveChangesAsync();

        Log.Information("User with email: {@Email} signed in successfully", request.Email);

        return Success(userToken);
    }
}
