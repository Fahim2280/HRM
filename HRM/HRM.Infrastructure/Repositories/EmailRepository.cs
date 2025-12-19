using HRM.Domain.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HRM.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                // Send to the actual user's email
                var actualRecipient = toEmail;

                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];

                // Validate configuration
                if (string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(senderPassword))
                {
                    Console.WriteLine($"Email configuration is missing. SenderEmail: {senderEmail}, SenderPassword: {!string.IsNullOrEmpty(senderPassword)}");
                    return false;
                }

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(actualRecipient);

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Verification email sent successfully to {actualRecipient}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send verification email to {toEmail}. Error: {ex.Message}");
                return false;
            }
        }
    }
}