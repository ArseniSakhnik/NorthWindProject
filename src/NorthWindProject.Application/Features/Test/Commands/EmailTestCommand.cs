using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Interfaces;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Test.Commands
{
    public class EmailTestCommand : IRequest
    {
        
    }
    
    public class EmailTestRequestHandler : IRequestHandler<EmailTestCommand>
    {
        private IEmailSenderService _emailSenderService;

        public EmailTestRequestHandler(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }


        public async Task<Unit> Handle(EmailTestCommand request, CancellationToken cancellationToken)
        {
            await _emailSenderService.SendEmailAsync("sakhnikarseni@mail.ru", "Арсений Сахник", "Тема письма", "Текст письма");
            return Unit.Value;
        }
    }
}