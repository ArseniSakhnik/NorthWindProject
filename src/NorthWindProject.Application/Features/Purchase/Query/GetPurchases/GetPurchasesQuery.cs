using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Purchase.Query.GetPurchases
{
    public class GetPurchasesQuery : IRequest<IList<PurchaseDto>>
    {
    }

    public class GetPurchasesQueryHandler : IRequestHandler<GetPurchasesQuery, IList<PurchaseDto>>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetPurchasesQueryHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }


        public async Task<IList<PurchaseDto>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
            => await _context.Purchases
                .Where(purchase => purchase.UserId == _currentUserService.UserId)
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
                })
                .ToListAsync(cancellationToken);
    }
}