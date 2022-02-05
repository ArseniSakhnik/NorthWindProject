using System.Threading.Tasks;
using NorthWind.API.Models;

namespace NorthWindProject.Application.Interfaces.DomainEvents
{
    public interface IEmailSenderService
    {
        void SendEmailAsync(EmailBodyModel emailBodyModel);
    }
}