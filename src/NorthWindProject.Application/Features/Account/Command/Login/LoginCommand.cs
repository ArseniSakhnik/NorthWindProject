using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NorthWind.Core.Entities.User;
using NorthWindProject.Application.Common.Exceptions;

namespace NorthWindProject.Application.Features.Account.Command.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _signInManager.PasswordSignInAsync(
                    request.Email,
                    request.Password,
                    request.RememberMe,
                    true);

            if (result.Succeeded)
                return "";

            if (result.IsNotAllowed)
                throw new ClientValidationException("Аккаунт не подтвержден");

            throw new ClientValidationException("Неверное имя пользователя или пароль");
        }
    }
}