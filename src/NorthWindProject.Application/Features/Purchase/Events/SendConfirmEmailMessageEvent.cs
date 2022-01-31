using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Events
{
    public class SendConfirmEmailMessageEvent : DomainEvent
    {
        public int PurchaseId { get; set; }
    }

    public class
        SendConfirmEmailMessageEventHandler : INotificationHandler<
            DomainEventNotification<SendConfirmEmailMessageEvent>>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;

        public SendConfirmEmailMessageEventHandler(AppDbContext context, IEmailSenderService emailSenderService)
        {
            _context = context;
            _emailSenderService = emailSenderService;
        }

        public async Task Handle(DomainEventNotification<SendConfirmEmailMessageEvent> notification,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}