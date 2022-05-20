using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Common;
using NorthWind.Core.Entities.Purchase;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Command.UpdateAssenizator;
using NorthWindProject.Application.Features.Purchase.Command.UpdateKGO;

namespace NorthWindProject.Application.Services.PurchaseService
{
    public class PurchaseService
    {
        private readonly ICurrentUserService _currentUserService;

        public PurchaseService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task CreatePurchase<T>(AppDbContext context, T purchase, CancellationToken cancellationToken)
            where T : Purchase
        {
            var currentUser = await context.Users
                .Where(user => user.Id == _currentUserService.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            AuditableEntityFill(purchase);
            currentUser.Purchases.Add(purchase);
        }

        public async Task<BasePurchaseDto> GetPurchase(
            AppDbContext context, int purchaseId,
            CancellationToken cancellationToken)
        {
            var purchase = await context.Purchases
                .AsNoTracking()
                .Where(purchase => purchase.Id == purchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            BasePurchaseDto response = purchase.ServiceTypeId switch
            {
                ServiceEnum.Ассенизатор => new AssenizatorPurchaseDto(),
                ServiceEnum.КГО => new KGOPurchaseDto(),
            };

            response.Id = purchase.Id;
            response.Email = purchase.Email;
            response.PhoneNumber = purchase.PhoneNumber;
            response.Name = purchase.Name;
            response.Surname = purchase.Surname;
            response.MiddleName = purchase.MiddleName;
            response.Place = purchase.Place;
            response.Comment = purchase.Comment;
            response.ServiceTypeId = purchase.ServiceTypeId;

            if (purchase is AssenizatorPurchase assenizatorPurchase)
            {
                ((AssenizatorPurchaseDto) response).WasteType = assenizatorPurchase.WasteTypeId;
                ((AssenizatorPurchaseDto) response).PitVolume = assenizatorPurchase.PitVolume;
                ((AssenizatorPurchaseDto) response).DistanceFromDriveway = assenizatorPurchase.DistanceFromDriveway;
            }

            if (purchase is KGOPurchase kgoPurchase)
            {
                ((KGOPurchaseDto) response).PlannedWasteVolume = kgoPurchase.PlannedWasteVolume;
                ((KGOPurchaseDto) response).DistanceFromDriveway = kgoPurchase.DistanceFromDriveway;
            }

            return response;
        }

        public async Task UpdatePurchase(AppDbContext context,
            int purchaseId,
            BasePurchaseCommand data,
            CancellationToken cancellationToken)
        {
            if (data is UpdateAssenizatorCommand assenizatorCommand)
            {
                var purchase = await context.AssenizatorPurchases
                    .Where(purchase => purchase.Id == purchaseId)
                    .SingleOrDefaultAsync(cancellationToken);

                purchase.Email = data.Email;
                purchase.PhoneNumber = data.PhoneNumber;
                purchase.Name = data.Name;
                purchase.Surname = data.Surname;
                purchase.MiddleName = data.MiddleName;
                purchase.Place = data.Place;
                purchase.Comment = data.Comment;

                purchase.WasteTypeId = assenizatorCommand.WasteType;
                purchase.PitVolume = assenizatorCommand.PitVolume;
                purchase.DistanceFromDriveway = assenizatorCommand.DistanceFromDriveway;
            }

            if (data is UpdateKGOCommand kgoCommand)
            {
                var purchase = await context.KgoPurchases
                    .Where(purchase => purchase.Id == purchaseId)
                    .SingleOrDefaultAsync(cancellationToken);

                purchase.Email = data.Email;
                purchase.PhoneNumber = data.PhoneNumber;
                purchase.Name = data.Name;
                purchase.Surname = data.Surname;
                purchase.MiddleName = data.MiddleName;
                purchase.Place = data.Place;
                purchase.Comment = data.Comment;

                purchase.PlannedWasteVolume = kgoCommand.PlannedWasteVolume;
                purchase.DistanceFromDriveway = kgoCommand.PlannedWasteVolume;
            }
        }
        
        private void AuditableEntityFill(AuditableEntity purchase)
        {
            purchase.CreatedByUsername = _currentUserService.UserName;
            purchase.CreatedByUserId = _currentUserService.UserId == 0
                ? null
                : _currentUserService.UserId;
            purchase.Created = DateTime.Now;
        }
    }
}