using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.UpdateKGO
{
    public class UpdateKGOCommand : BasePurchaseCommand, IRequest
    {
        public int Id { get; set; }
        public int PlannedWasteVolume { get; set; }
        public int DistanceFromDriveway { get; set; }
    }

    public class UpdateKGOCommandHandler : IRequestHandler<UpdateKGOCommand>
    {
        private readonly PurchaseService _purchaseService;
        private readonly AppDbContext _context;

        public UpdateKGOCommandHandler(PurchaseService purchaseService, AppDbContext context)
        {
            _purchaseService = purchaseService;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateKGOCommand request, CancellationToken cancellationToken)
        {
            await _purchaseService.UpdatePurchase(_context, request.Id, request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}