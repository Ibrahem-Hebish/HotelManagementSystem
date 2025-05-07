namespace Services.Email;

public interface IEmailService
{
    Task SendEmail(EmailContent emailContent);
}



