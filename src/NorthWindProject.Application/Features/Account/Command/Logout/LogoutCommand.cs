using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NorthWind.Core.Entities.User;

namespace NorthWindProject.Application.Features.Account.Command.Logout
{
    public class LogoutCommand : IRequest
    {
    }

    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}