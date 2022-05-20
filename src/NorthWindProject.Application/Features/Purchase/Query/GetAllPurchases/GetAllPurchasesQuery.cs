using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Purchase.Query.GetAllPurchases
{
    public class GetAllPurchasesQuery : IRequest<PurchaseAndPageCountDto>
    {
        public int Page { get; set; }
        public string SearchName { get; set; }
        public ConfirmedType ConfirmedTypeId { get; set; }
    }

    public class GetAllPurchasesQueryHandler : IRequestHandler<GetAllPurchasesQuery, PurchaseAndPageCountDto>
    {
        private readonly AppDbContext _context;

        public GetAllPurchasesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseAndPageCountDto> Handle(GetAllPurchasesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Purchases
                .AsNoTracking()
                .AsQueryable();

            if (request.SearchName != null && request.SearchName.Trim().Length > 0)
            {
                query = query
                    .Where(purchase =>
                        purchase.User.FullName.ToLower().Trim().Contains(request.SearchName.ToLower().Trim())
                        ||
                        purchase.Place.ToLower().Trim().Contains(request.SearchName.ToLower().Trim())
                    );
            }

            if (request.ConfirmedTypeId != ConfirmedType.НеПроверять)
            {
                query = request.ConfirmedTypeId == ConfirmedType.Подтверждено
                    ? query
                        .Where(purchase => purchase.IsConfirmed)
                    : query
                        .Where(purchase => !purchase.IsConfirmed);
            }

            var purchases = await query
                .Skip((request.Page - 1) * 10)
                .Take(10)
                .OrderByDescending(contract => contract.Created)
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
                    UserFullName = purchase.User.FullName,
                    IsConfirmed = purchase.IsConfirmed,
                    Created = purchase.Created.ToIsoString()
                })
                .ToListAsync(cancellationToken);

            var purchasesCount = await query.CountAsync(cancellationToken);

            return new PurchaseAndPageCountDto
            {
                Purchases = purchases,
                PagesCount = (int) Math.Ceiling((decimal) purchasesCount / 10)
            };
        }
    }
}