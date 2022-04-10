using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetPurchases
{
    // public class GetPurchasesQuery : IRequest<IQueryable<PurchaseDto>>
    // {
    //     
    // }
    //
    // public class GetPurchasesQueryHandler : IRequestHandler<GetPurchasesQuery, IQueryable<PurchaseDto>>
    // {
    //     private readonly AppDbContext _context;
    //
    //     public GetPurchasesQueryHandler(AppDbContext context)
    //     {
    //         _context = context;
    //     }
    //
    //     //а как вообще заявка то создается
    //     public Task<IQueryable<PurchaseDto>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
    //     => Task.FromResult(_context.Purchases.Where())
    // }
}