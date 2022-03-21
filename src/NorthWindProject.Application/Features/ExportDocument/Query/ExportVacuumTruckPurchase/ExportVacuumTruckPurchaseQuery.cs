using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportPurchase;

namespace NorthWindProject.Application.Features.ExportDocument.Query.ExportVacuumTruckPurchase
{
    public class ExportVacuumTruckPurchaseQuery : IRequest<FileModel>
    {
        public int PurchaseId { get; set; }
    }

    public class ExportVacuumTruckPurchaseQueryHandler : IRequestHandler<ExportVacuumTruckPurchaseQuery, FileModel>
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public ExportVacuumTruckPurchaseQueryHandler(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<FileModel> Handle(ExportVacuumTruckPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchase = await _context.FizVacuumTruckPurchases
                .Where(purchase => purchase.Id == request.PurchaseId)
                .SingleOrDefaultAsync(cancellationToken);

            return await _mediator.Send(new ExportPurchaseQuery
            {
                Purchase = purchase,
            }, cancellationToken);
        }
    }
}