using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetAllPurchases
{
    public class GetAllPurchasesQuery : IRequest<IList<PurchaseDto>>
    {
        public int Page { get; set; }
        public string SearchName { get; set; }
        public ConfirmedType ConfirmedTypeId { get; set; }
    }

    public class GetAllPurchasesQueryHandler : IRequestHandler<GetAllPurchasesQuery, IList<PurchaseDto>>
    {
        private readonly AppDbContext _context;

        public GetAllPurchasesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<PurchaseDto>> Handle(GetAllPurchasesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Purchases
                .AsNoTracking()
                .AsQueryable();

            if (request.SearchName != null && request.SearchName.Trim().Length > 0)
            {
                query = query
                    .Where(purchase =>
                        purchase.User.FullName.ToLower().Trim().Contains(request.SearchName.ToLower().Trim()));
            }

            if (request.ConfirmedTypeId != ConfirmedType.НеПроверять)
            {
                query = request.ConfirmedTypeId == ConfirmedType.Подтверждено
                    ? query
                        .Where(purchase => purchase.IsConfirmed)
                    : query
                        .Where(purchase => !purchase.IsConfirmed);
            }

            query = query
                    .Take(10)
                    .Skip((request.Page - 1) * 10);

            return await query
                .Select(purchase => new PurchaseDto
                {
                    Id = purchase.Id,
                    Email = purchase.Email,
                    PhoneNumber = purchase.PhoneNumber,
                    Name = purchase.Name,
                    Surname = purchase.Surname,
                    MiddleName = purchase.MiddleName,
                    Place = purchase.Place,
                    Comment = purchase.Comment,
                    ServiceTypeId = purchase.ServiceTypeId,
                    UserFullName = purchase.User.FullName
                })
                .ToListAsync(cancellationToken);
        }
    }
}