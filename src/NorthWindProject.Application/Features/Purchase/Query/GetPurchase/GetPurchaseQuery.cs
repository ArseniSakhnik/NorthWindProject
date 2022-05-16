using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services;
using NorthWindProject.Application.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Query.GetPurchase
{
    public class GetPurchaseQuery : IRequest<BasePurchaseDto>
    {
        public int PurchaseId { get; set; }
    }

    public class GetPurchaseQueryHandler : IRequestHandler<GetPurchaseQuery, BasePurchaseDto>
    {
        private readonly PurchaseService _purchaseService;
        private readonly AppDbContext _context;

        public GetPurchaseQueryHandler(PurchaseService purchaseService, AppDbContext context)
        {
            _purchaseService = purchaseService;
            _context = context;
        }

        public async Task<BasePurchaseDto> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
            => await _purchaseService.GetPurchase(_context, request.PurchaseId, cancellationToken);
    }
}