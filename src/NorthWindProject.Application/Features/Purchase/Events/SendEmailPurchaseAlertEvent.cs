using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Purchases.BasePurchase;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportPurchase;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Events
{
    public class SendEmailPurchaseAlertEvent : DomainEvent
    {
        public Entities.Purchases.BasePurchase.Purchase Purchase { get; set; }
        public string Email { get; set; }
    }

    public class
        SendEmailPurchaseAlertHandler : INotificationHandler<DomainEventNotification<SendEmailPurchaseAlertEvent>>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public SendEmailPurchaseAlertHandler(IEmailSenderService emailSenderService, IMediator mediator,
            AppDbContext context)
        {
            _emailSenderService = emailSenderService;
            _mediator = mediator;
            _context = context;
        }

        public async Task Handle(DomainEventNotification<SendEmailPurchaseAlertEvent> notification,
            CancellationToken cancellationToken)
        {
            var purchase = notification.DomainEvent.Purchase;

            var purchaseFile = await _mediator.Send(new ExportPurchaseQuery
            {
                PurchaseId = purchase.Id,
            }, cancellationToken);

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = notification.DomainEvent.Email,
                Username = "Здравствуйте!",
                Subject = "Вы отправили заявку",
                HtmlBody = $"<div>Ваша заявка</div>",
                Files = new List<FileModel> {purchaseFile}
            });
        }
    }
}