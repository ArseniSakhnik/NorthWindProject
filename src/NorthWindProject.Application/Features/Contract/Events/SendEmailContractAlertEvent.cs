using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;
using NorthWindProject.Application.Common.Models;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportContract;

namespace NorthWindProject.Application.Features.Contract.Events
{
    public class SendEmailContractAlertEvent : DomainEvent
    {
        public NorthWind.Core.Entities.Contracts.BaseContract.Contract Contract { get; set; }
        public string Email { get; set; }
    }

    public class
        SendEmailContractAlertEventHandler : INotificationHandler<DomainEventNotification<SendEmailContractAlertEvent>>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IMediator _mediator;

        public SendEmailContractAlertEventHandler(IEmailSenderService emailSenderService, IMediator mediator,
            AppDbContext context)
        {
            _emailSenderService = emailSenderService;
            _mediator = mediator;
            _context = context;
        }

        public async Task Handle(DomainEventNotification<SendEmailContractAlertEvent> notification,
            CancellationToken cancellationToken)
        {
            var contract = notification.DomainEvent.Contract;

            var contractFile = await _mediator.Send(new ExportContractQuery
            {
                ContractId = contract.Id
            }, cancellationToken);

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = notification.DomainEvent.Email,
                Username = "Здравствуйте!",
                Subject = "Вы отправили заявку",
                HtmlBody = "<div>Ваша заявка</div>",
                Files = new List<FileModel> {contractFile}
            });
        }
    }
}