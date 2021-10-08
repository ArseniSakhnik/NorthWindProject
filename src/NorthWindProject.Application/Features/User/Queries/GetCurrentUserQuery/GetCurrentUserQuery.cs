using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.User.Queries.GetCurrentUserQuery
{
    public class GetCurrentUserQuery : IRequest<CurrentUserDto>
    { }

    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, CurrentUserDto>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserQueryHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<CurrentUserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.UserRoles
                .Where(role => role.UserId == _currentUserService.UserId)
                .AsNoTracking()
                .Select(role => new RoleDto
                {
                    Id = role.RoleId,
                    Name = ((RolesEnum) role.RoleId).ToString()
                })
                .ToListAsync(cancellationToken);

            return await _context.Users
                .Where(user => user.Id == _currentUserService.UserId)
                .AsNoTracking()
                .Select(user => new CurrentUserDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsAuthenticated = _currentUserService.IsAuthenticated,
                    Roles = roles
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}