﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;
using NorthWindProject.Application.Common.Models;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportPurchase;

namespace NorthWindProject.Application.Features.Purchase.Events
{
    public class SendEmailPurchaseAlertEvent : DomainEvent
    {
        public NorthWind.Core.Entities.Purchases.BasePurchase.Purchase Purchase { get; set; }
        public string Email { get; set; }
    }

    public class
        SendEmailPurchaseAlertHandler : INotificationHandler<DomainEventNotification<SendEmailPurchaseAlertEvent>>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IMediator _mediator;

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
                PurchaseId = purchase.Id
            }, cancellationToken);

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = notification.DomainEvent.Email,
                Username = "Здравствуйте!",
                Subject = "Вы отправили заявку",
                HtmlBody = "<div>Ваша заявка</div>",
                Files = new List<FileModel> {purchaseFile}
            });
        }
    }
}