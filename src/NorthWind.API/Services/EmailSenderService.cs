using System.Threading.Tasks;
using AutoMapper.Internal;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NorthWind.API.Configuration;
using NorthWind.API.Models;
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

        public async Task SendEmailAsync(EmailBodyModel emailBodyModel)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("NorthWind", _senderEmail));
            emailMessage.To.Add(new MailboxAddress(emailBodyModel.Username, emailBodyModel.ToEmail));
            //тайтл сообщения?
            emailMessage.Subject = emailBodyModel.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = emailBodyModel.HtmlBody
            };

            emailBodyModel.Files.ForAll(file => builder.Attachments.Add($"{file.Name}.doc", file.Content));
            emailMessage.Body = builder.ToMessageBody();

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.mail.ru", 465);
            await client.AuthenticateAsync(_senderEmail, _senderEmailPassword);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}