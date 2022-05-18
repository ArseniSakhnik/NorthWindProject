using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Purchase;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services;
using NorthWindProject.Application.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.CreateAssenizatorPurchase
{
    public class AssenizatorPurchaseCommandCommand : BaseCreatePurchase.BasePurchaseCommand, IRequest
    {
        public WasteType WasteType { get; set; }

        public int PitVolume { get; set; }

        public int DistanceFromDriveway { get; set; }
    }

    public class CreateAssenizatorPurchaseCommandHandler : IRequestHandler<AssenizatorPurchaseCommandCommand>
    {
        private readonly PurchaseService _purchaseService;
        private readonly AppDbContext _context;

        public CreateAssenizatorPurchaseCommandHandler(PurchaseService purchaseService, AppDbContext context)
        {
            _purchaseService = purchaseService;
            _context = context;
        }

        public async Task<Unit> Handle(AssenizatorPurchaseCommandCommand request, CancellationToken cancellationToken)
        {
            var purchase = new AssenizatorPurchase
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Name = request.PhoneNumber,
                Surname = request.Surname,
                MiddleName = request.MiddleName,
                Place = request.Place,
                Comment = request.Comment,
                WasteTypeId = request.WasteType,
                PitVolume = request.PitVolume,
                DistanceFromDriveway = request.DistanceFromDriveway,
                ServiceTypeId = ServiceEnum.Ассенизатор
            };

            await _purchaseService.CreatePurchase(_context, purchase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}