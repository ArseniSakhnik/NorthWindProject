using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Features.Purchase.Query.GetUserPurchases
{
    public class GetUserPurchasesQuery : IRequest<IList<UserPurchaseDto>>
    {
    }

    public class GetUserPurchasesQueryHandler : IRequestHandler<GetUserPurchasesQuery, IList<UserPurchaseDto>>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetUserPurchasesQueryHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }


        public async Task<IList<UserPurchaseDto>> Handle(GetUserPurchasesQuery request, CancellationToken cancellationToken)
            => await _context.Purchases
                .Where(purchase => purchase.UserId == _currentUserService.UserId)
                .Select(purchase => new UserPurchaseDto
                {
                    Id = purchase.Id,
                    Email = purchase.Email,
                    PhoneNumber = purchase.PhoneNumber,
                    Name = purchase.Name,
                    Surname = purchase.Surname,
                    MiddleName = purchase.MiddleName,
                    PlaceName = purchase.Place,
                    Comment = purchase.Comment,
                    ServiceTypeId = purchase.ServiceTypeId,
                    Created = purchase.Created.ToIsoString()
                })
                .ToListAsync(cancellationToken);
    }
}