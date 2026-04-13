using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace CodeCircle.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpKey = _config["BrevoKey"];
            var loginEmail = _config["BrevoEmail"];

            if (string.IsNullOrEmpty(smtpKey) || string.IsNullOrEmpty(loginEmail))
            {
                throw new Exception("CRITICAL ERROR: Brevo credentials missing from User Secrets");
            }

            // 1. Configure the SMTP Client safely line-by-line
            using var client = new SmtpClient("smtp-relay.brevo.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(loginEmail, smtpKey);
            client.EnableSsl = true;

            // 2. Draft the email
            var mailMessage = new MailMessage
            {
                From = new MailAddress(loginEmail, "CodeCircle Server"),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            // 3. Fire it off!
            await client.SendMailAsync(mailMessage);
        }
    }
}
