using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Events;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Services.PurchaseService
{
    public interface IPurchaseService
    {
        public Task CreatePurchaseAsync<TData, TPurchase>(
            Func<TData, TPurchase> purchaseFactory,
            TData purchaseData,
            ServicesEnum serviceTypeId,
            CancellationToken cancellationToken)
            where TPurchase : Entities.Purchases.BasePurchase.Purchase
            where TData : BaseCreatePurchaseCommand;
    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IEncryptionService _encryptionService;

        public PurchaseService(IMediator mediator,
            AppDbContext context,
            ICurrentUserService currentUserService,
            IEncryptionService encryptionService)
        {
            _mediator = mediator;
            _context = context;
            _currentUserService = currentUserService;
            _encryptionService = encryptionService;
        }

        public async Task CreatePurchaseAsync<TData, TPurchase>(
            Func<TData, TPurchase> purchaseFactory,
            TData purchaseData,
            ServicesEnum serviceTypeId,
            CancellationToken cancellationToken)
            where TPurchase : Entities.Purchases.BasePurchase.Purchase
            where TData : BaseCreatePurchaseCommand

        {
            var currentUser = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id == _currentUserService.UserId, cancellationToken);

            var service = await _context.Services
                .Include(service => service.DocumentServices)
                .AsNoTracking()
                .SingleOrDefaultAsync(service => service.Id == serviceTypeId, cancellationToken);

            var currentDate = DateTime.Now;

            var purchase = purchaseFactory(purchaseData);

            purchase.Day = currentDate.Day.ToString();
            purchase.Month = currentDate.Month.ToString();
            purchase.Year = currentDate.Year.ToString();

            purchase.UserId = currentUser.Id;
            purchase.ServiceId = service.Id;
            purchase.DocumentServiceId = service.DocumentServices.First().Id;

            if (purchase is IEncryptObject purchaseEncrypt)
            {
                purchaseEncrypt.EncryptObject(_encryptionService);
            }

            purchase.DomainEvents.Add(new SendEmailPurchaseAlertEvent
            {
                Email = purchaseData.Email,
                Purchase = purchase,
            });
            currentUser.Purchases.Add(purchase);

            await _context.Purchases.AddAsync(purchase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}