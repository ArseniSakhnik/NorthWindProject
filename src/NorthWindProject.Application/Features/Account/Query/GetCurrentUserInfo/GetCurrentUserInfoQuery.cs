using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo
{
    public class GetCurrentUserInfoQuery : IRequest<UserDto>
    {
    }

    public class GetCurrentUserInfoQueryHandler : IRequestHandler<GetCurrentUserInfoQuery, UserDto>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserInfoQueryHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<UserDto> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
        {
            return _currentUserService.UserId == 0
                ? new UserDto()
                : await _context.Users
                    .Where(user => user.Id == _currentUserService.UserId)
                    .Select(user => new UserDto
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        EmailConfirmed = user.EmailConfirmed,
                        PhoneNumber = user.PhoneNumber,
                        Name = user.Name,
                        Surname = user.Surname,
                        MiddleName = user.MiddleName,
                        FullName = $"{user.Name} {user.MiddleName} {user.Surname}"
                    })
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}