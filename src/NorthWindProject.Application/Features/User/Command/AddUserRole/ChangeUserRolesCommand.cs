using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Entities.User;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.User.Command.AddUserRole
{
    public class ChangeUserRolesCommand : IRequest
    {
        public int UserId { get; set; }
        public IList<RolesEnum> Roles { get; set; }
    }
    
    public class ChangeUserRolesCommandHandler : IRequestHandler<ChangeUserRolesCommand>
    {
        private readonly AppDbContext _context;

        public ChangeUserRolesCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeUserRolesCommand request, CancellationToken cancellationToken)
        {
            var userRoles = await _context.UserRoles
                .Where(ur => ur.UserId == request.UserId)
                .ToListAsync(cancellationToken);
            
            _context.UserRoles.RemoveRange(userRoles);

            var newUserRoles = request.Roles
                .Select(role => new IdentityUserRole<int>
                {
                    UserId = request.UserId,
                    RoleId = (int) role
                })
                .ToList();

            await _context.UserRoles.AddRangeAsync(newUserRoles, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}