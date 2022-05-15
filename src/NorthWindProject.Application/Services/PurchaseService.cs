using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.Purchase;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Services
{
    public class PurchaseService
    {
        private readonly ICurrentUserService _currentUserService;

        public PurchaseService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task CreatePurchase<T>(AppDbContext context, T purchase, CancellationToken cancellationToken)
            where T : Purchase
        {
            var currentUser = await context.Users
                .Where(user => user.Id == _currentUserService.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            currentUser.Purchases.Add(purchase);
        }
    }
}