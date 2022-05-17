using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Command.ApprovePurchase
{
    public class ConfirmPurchaseCommand : IRequest
    {
        public int PurchaseId { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class ConfirmPurchaseCommandHandler : IRequestHandler<ConfirmPurchaseCommand>
    {
        private readonly AppDbContext _context;

        public ConfirmPurchaseCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ConfirmPurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases
                .Where(purchase => purchase.Id == request.PurchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            purchase.IsConfirmed = request.IsConfirmed;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}