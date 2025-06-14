using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class SendCodeToReseatPasswordHanlder(UserManager<User> userManager,
       IEmailService emailService)
    : ResponseHandler,
    IRequestHandler<SendCodeToReseatPassword, Response<string>>
{
    public async Task<Response<string>> Handle(SendCodeToReseatPassword request, CancellationToken cancellationToken)
    {
        Log.Information("Sending code to reseat password for email: {@Email}", request.Email);

        var user = await userManager.FindByEmailAsync(request.Email!);

        if (user is null)
        {
            Log.Error("User with email: {@Email} not found", request.Email);
            return NotFouned<string>("User not found");
        }

        var code = await userManager.GeneratePasswordResetTokenAsync(user);

        if (string.IsNullOrWhiteSpace(code))
        {
            Log.Error("Failed to generate code for user with email: {@Email}", request.Email);
            return BadRequest<string>("Failed to generate code");
        }

        user.Code = code;

        var isUpdated = await userManager.UpdateAsync(user);

        if (!isUpdated.Succeeded)
        {
            Log.Error("Failed to update user with email: {@Email}", request.Email);
            return BadRequest<string>("Failed to update user");
        }

        var email = new EmailContent
        {
            Email = request.Email,
            Subject = "Reseat Password Code",
            Message = $"Your reseat password code is: {code}. Please use this code to reseat your password."

        };

        try
        {
            await emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to send email to {@Email}", request.Email);
            return BadRequest<string>("Failed to send email");
        }

        Log.Information("Code sent to reseat password for email: {@Email}", request.Email);

        return Success("Code sent successfully");
    }
}