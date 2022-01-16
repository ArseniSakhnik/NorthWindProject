using System.Threading.Tasks;

namespace NorthWindProject.Application.Interfaces.DomainEvents
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string toEmail, string username, string subject, string message);
    }
}