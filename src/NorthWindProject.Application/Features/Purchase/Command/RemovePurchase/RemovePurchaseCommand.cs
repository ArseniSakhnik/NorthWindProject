using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Command.RemovePurchase
{
    public class RemovePurchaseCommand : IRequest
    {
        public int PurchaseId { get; set; }
    }

    public class RemovePurchaseCommandHandler : IRequestHandler<RemovePurchaseCommand>
    {
        private readonly AppDbContext _context;

        public RemovePurchaseCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemovePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases
                .Where(purchase => purchase.Id == request.PurchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            _context.Purchases.Remove(purchase);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}