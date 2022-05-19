using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Common.Extensions
{
    public static class AppDbContextExtensions
    {
        public static async Task<bool> IsCurrentUserAdmin(this AppDbContext context, int userId,
            CancellationToken cancellationToken)
        {
            return await context.UserRoles
                .AnyAsync(usr => usr.UserId == userId
                                 &&
                                 usr.RoleId == (int) RolesEnum.Админ, cancellationToken);
        }
    }
}