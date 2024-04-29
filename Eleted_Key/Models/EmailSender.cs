using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Implementarea reală aici pentru trimiterea email-ului
        var smtpClient = new SmtpClient("your-smtp-server.com")
        {
            Port = 587,
            Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-password"),
            EnableSsl = true,
        };

        return smtpClient.SendMailAsync("your-email@example.com", email, subject, htmlMessage);
    }
}
