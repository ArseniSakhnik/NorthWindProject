using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Features.ExportDocument.Query;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Events.SendConfirmPurchaseEmailEvent
{
    public class SendConfirmPurchaseEmailEvent : DomainEvent
    {
        public string Email { get; set; }
        public string ServiceName { get; set; }

        public int PurchaseId { get; set; }
        public Entities.Purchase.Purchase Purchase { get; set; }

        public SendConfirmPurchaseEmailEvent(int purchaseId)
        {
            PurchaseId = purchaseId;
        }

        public SendConfirmPurchaseEmailEvent(Entities.Purchase.Purchase purchase)
        {
            Purchase = purchase;
        }
    }

    public class
        SendConfirmPurchaseEmailEventHandler : INotificationHandler<
            DomainEventNotification<SendConfirmPurchaseEmailEvent>>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public SendConfirmPurchaseEmailEventHandler(AppDbContext context,
            IEmailSenderService emailSenderService,
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator)
        {
            _context = context;
            _emailSenderService = emailSenderService;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        public async Task Handle(DomainEventNotification<SendConfirmPurchaseEmailEvent> notification,
            CancellationToken cancellationToken)
        {
            var purchase = notification.DomainEvent.Purchase ?? await _context.Purchases
                .Where(purchaseDb => purchaseDb.Id == notification.DomainEvent.PurchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            var confirm = new ConfirmPurchase
            {
                PurchaseId = purchase.Id,
                Guid = new Guid().ToString()
            };

            var registerRequest = _httpContextAccessor.HttpContext.Request;
            var callbackUrl =
                $"{registerRequest.Scheme}://{registerRequest.Host.Value}/confirm-purchase?userId={purchase.Id}&code={confirm.Guid}";

            await _context.ConfirmPurchases.AddAsync(confirm, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var serviceName = notification.DomainEvent.ServiceName;

            var fileToConfirm = await
                _mediator.Send(new ExportPurchaseQuery(serviceName, purchase), cancellationToken);

            await _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = notification.DomainEvent.Email,
                Username = "Здравствуйте!",
                Subject = "Подтверждение аккаунта",
                HtmlBody =
                    $"<div>Подтвердите ваши заявки, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>",
                Files = new List<FileModel> {fileToConfirm}
            });
        }
    }
}