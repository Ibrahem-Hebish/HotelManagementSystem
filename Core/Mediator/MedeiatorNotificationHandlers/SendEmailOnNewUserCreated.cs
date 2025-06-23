namespace Core.Mediator.MedeiatorNotificationHandlers;

public class SendEmailOnNewUserCreated(IEmailService emailService,
    IHttpContextAccessor httpContextAccessor,
    UserManager<User> userManager)

    : INotificationHandler<UserCreatedNotification>
{
    public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(notification.User);

            var emailContent = new EmailContent()
            {
                Email = notification.User.Email!,
                Subject = "Welcome To Our Service",
                Message = $"""
                                <h2>Hello, {notification.User.UserName}.<br/>We wish you a happy day.</h2>
                                <h3 
                                   style="background-color: #4CAF50; color: white; padding: 10px 20px; 
                                          border: none; border-radius: 5px; cursor: pointer;">
                                   Confirm Email, Here is your code : {token}
                                </h3>
                            """
            };

            await emailService.SendEmail(emailContent);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error while sending email to user {@Email}", notification.User.Email);

            httpContextAccessor.HttpContext!.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            throw new Exception("Error while sending email", ex);

        }
    }
}
