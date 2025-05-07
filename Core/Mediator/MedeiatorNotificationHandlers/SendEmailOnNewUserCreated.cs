namespace Core.Mediator.MedeiatorNotificationHandlers;

public class SendEmailOnNewUserCreated(IEmailService emailService,
    IHttpContextAccessor httpContextAccessor)

    : INotificationHandler<UserCreatedNotification>
{
    public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            var emailContent = new EmailContent()
            {
                Email = notification.User.Email!,
                Subject = "Welcome TO Our Service",
                Message = $"Hello, {notification.User.UserName}.\n\tWe wish you a happy day."
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
