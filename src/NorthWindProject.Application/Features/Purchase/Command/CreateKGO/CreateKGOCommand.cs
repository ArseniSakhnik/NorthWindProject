using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Purchase;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services;
using NorthWindProject.Application.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.CreateKGO
{
    public class CreateKGOCommand : BaseCreatePurchase.BaseCreatePurchaseCommand, IRequest
    {
        //какой объем мусора планируется вывозить 
        public int PlannedWasteVolume { get; set; }

        // Расстояние от подъездного пути в метрах
        public int DistanceFromDriveway { get; set; }
    }

    public class CreateKgoCommandHandler : IRequestHandler<CreateKGOCommand>
    {
        private readonly AppDbContext _context;
        private readonly PurchaseService _purchaseService;

        public CreateKgoCommandHandler(AppDbContext context, PurchaseService purchaseService)
        {
            _context = context;
            _purchaseService = purchaseService;
        }

        public async Task<Unit> Handle(CreateKGOCommand request, CancellationToken cancellationToken)
        {
            var purchase = new KGOPurchase
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Name = request.PhoneNumber,
                Surname = request.Surname,
                MiddleName = request.MiddleName,
                Place = request.Place,
                Comment = request.Comment,
                PlannedWasteVolume = request.PlannedWasteVolume,
                DistanceFromDriveway = request.DistanceFromDriveway,
                ServiceTypeId = ServiceViewEnum.КГО
            };

            await _purchaseService.CreatePurchase(_context, purchase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}