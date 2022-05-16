using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.UpdateAssenizator
{
    public class UpdateAssenizatorCommand : BasePurchaseCommand, IRequest
    {
        public int PurchaseId { get; set; }

        public WasteType WasteType { get; set; }

        public int PitVolume { get; set; }

        public int DistanceFromDriveway { get; set; }
    }

    public class UpdateAssenizatorCommandHandler : IRequestHandler<UpdateAssenizatorCommand>
    {
        private readonly AppDbContext _context;
        private readonly PurchaseService _purchaseService;

        public UpdateAssenizatorCommandHandler(AppDbContext context, PurchaseService purchaseService)
        {
            _context = context;
            _purchaseService = purchaseService;
        }

        public async Task<Unit> Handle(UpdateAssenizatorCommand request, CancellationToken cancellationToken)
        {
            await _purchaseService.UpdatePurchase(_context, request.PurchaseId, request, cancellationToken);
            return Unit.Value;
        }
    }
}