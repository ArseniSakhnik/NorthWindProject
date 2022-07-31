using NorthWindProject.Application.Common.Models;

namespace NorthWindProject.Application.Common.Interfaces.DomainEvents
{
    public interface IEmailSenderService
    {
        void SendEmailAsync(EmailBodyModel emailBodyModel);
    }
}