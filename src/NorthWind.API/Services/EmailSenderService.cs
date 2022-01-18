using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using NorthWind.API.Configuration;
using MailKit.Net.Smtp;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _senderEmail;
        private readonly string _senderEmailPassword;

        public EmailSenderService(IOptions<EmailSettings> emailOptions)
        {
            _senderEmail = emailOptions.Value.SenderEmail;
            _senderEmailPassword = emailOptions.Value.SenderEmailPassword;
        }

        public async Task SendEmailAsync(string toEmail, string username, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("NorthWind", _senderEmail));
            emailMessage.To.Add(new MailboxAddress(username, toEmail));
            //тайтл сообщения?
            emailMessage.Subject = subject;
            emailMessage.Body = new BodyBuilder
                {
                    HtmlBody = message
                }
                .ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(_senderEmail, _senderEmailPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}