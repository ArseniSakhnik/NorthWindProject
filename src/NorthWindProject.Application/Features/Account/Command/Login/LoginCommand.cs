using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Features.Account.Command.Login
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResultDto>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result =
                await _signInManager.PasswordSignInAsync(
                    request.Email,
                    request.Password,
                    request.RememberMe,
                    true);

            if (result.Succeeded)
                return new LoginResultDto
                {
                    IsSucceed = true,
                    Message = ""
                };

            if (result.IsNotAllowed)
                return new LoginResultDto
                {
                    IsSucceed = false,
                    Message = "Аккаунт не подтвержден"
                };

            return new LoginResultDto
            {
                IsSucceed = false,
                Message = "Неверное имя пользователя или пароль"
            };
        }
    }
}