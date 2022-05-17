using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetPages
{
    public class GetPagesQuery : IRequest<int>
    {
    }

    public class GetPagesQueryHandler : IRequestHandler<GetPagesQuery, int>
    {
        private readonly AppDbContext _context;

        public GetPagesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetPagesQuery request, CancellationToken cancellationToken)
        {
            decimal purchaseCount = await _context.Purchases.CountAsync(cancellationToken);

            return (int) Math.Ceiling(purchaseCount / 10);
        }
    }
}