using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Events.SendConfirmPurchaseEmailEvent
{
    public class SendConfirmPurchaseEmailEvent : DomainEvent
    {
        public int PurchaseId { get; set; }

        public string Email { get; set; }
    }

    public class
        SendConfirmPurchaseEmailEventHandler : INotificationHandler<
            DomainEventNotification<SendConfirmPurchaseEmailEvent>>
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SendConfirmPurchaseEmailEventHandler(AppDbContext context, 
            IEmailSenderService emailSenderService,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _emailSenderService = emailSenderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(DomainEventNotification<SendConfirmPurchaseEmailEvent> notification,
            CancellationToken cancellationToken)
        {
            var purchaseId = notification.DomainEvent.PurchaseId;

            var confirm = new ConfirmPurchase
            {
                PurchaseId = purchaseId,
                Guid = new Guid().ToString()
            };
            var registerRequest = _httpContextAccessor.HttpContext.Request;
            var callbackUrl =
                $"{registerRequest.Scheme}://{registerRequest.Host.Value}/confirm-purchase?userId={purchaseId}&code={confirm.Guid}";

            await _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = notification.DomainEvent.Email,
                Username = "Здравствуйте!",
                Subject = "Подтверждение аккаунта",
                HtmlBody =
                    $"<div>Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>",
            });
            
            await _context.ConfirmPurchases.AddAsync(confirm, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}