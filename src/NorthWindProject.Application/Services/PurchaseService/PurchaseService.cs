using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Purchase;
using NorthWind.Core.Enums;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

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
                ServiceViewEnum.Ассенизатор => new AssenizatorPurchaseDto(),
                ServiceViewEnum.КГО => new KGOPurchaseDto(),
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
    }
}