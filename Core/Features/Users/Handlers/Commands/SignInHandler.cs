using Core.Features.Users.Commands;
using Core.Features.Users.Dtos;

namespace Core.Features.Users.Handlers.Commands;

public class SignInHandler(UserManager<User> userManager,
    IAuthenticationService authenticationService,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IEmailService emailService)
    : ResponseHandler,
    IRequestHandler<SignIn, Response<UserTokenDto>>
{
    public async Task<Response<UserTokenDto>> Handle(SignIn request, CancellationToken cancellationToken)
    {
        Log.Information("Signing in user with email: {@Email}", request.Email);

        var user = await userManager.FindByEmailAsync(request.Email!);

        if (user is null)
        {
            Log.Error("User with email: {@Email} not found", request.Email);

            return BadRequest<UserTokenDto>("Invalid Credintials");
        }

        var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password);

        if (!isValidPassword)
        {
            Log.Error("Invalid password for user with email: {@Email}", request.Email);

            return BadRequest<UserTokenDto>("Invalid Credintials");
        }

        if (!user.EmailConfirmed)
        {
            Log.Error("Email not confirmed for user with email: {@Email}", request.Email);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            var encodedToken = Uri.EscapeDataString(token);

            var emailContent = new EmailContent()
            {
                Email = user.Email!,
                Subject = "Welcome To Our Service",
                Message = $"""
                                <h2>Hello, {user.UserName}.<br/>We wish you a happy day.</h2>
                                <h3 
                                   style="background-color: #4CAF50; color: white; padding: 10px 20px; 
                                          border: none; border-radius: 5px; cursor: pointer;">
                                   Confirm Email, Here is your code : {encodedToken}
                                <h3>
                            """
            };

            await emailService.SendEmail(emailContent);


            return BadRequest<UserTokenDto>("Email is not confirmed, We send you an email to confirm");
        }

        var userToken = await authenticationService.CreateToken(user, DateTime.UtcNow.AddMonths(3));

        var userTokenDto = mapper.Map<UserTokenDto>(userToken);

        await unitOfWork.SaveChangesAsync();

        Log.Information("User with email: {@Email} signed in successfully", request.Email);

        return Success(userTokenDto);
    }
}
