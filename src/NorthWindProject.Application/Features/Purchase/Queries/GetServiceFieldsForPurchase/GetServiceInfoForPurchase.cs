using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Queries.GetServiceFieldsForPurchase
{
    public class GetServiceInfoForPurchaseQuery : IRequest<PurchaseFieldsDto>
    {
        public int ServiceId { get; set; }
    }

    public class GetServiceFieldsForPurchaseQueryHandler : IRequestHandler<GetServiceInfoForPurchaseQuery, PurchaseFieldsDto>
    {
        private readonly AppDbContext _context;

        public GetServiceFieldsForPurchaseQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<PurchaseFieldsDto> Handle(GetServiceInfoForPurchaseQuery request, CancellationToken cancellationToken)
        {
            return await _context.Services
                .Where(service => service.ServiceId == request.ServiceId)
                .Select(service => new PurchaseFieldsDto(service.Name, service.Description, service.ServiceProps))
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}