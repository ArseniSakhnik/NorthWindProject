using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.Core.Entities.User;
using NorthWindProject.Application.Common.Exceptions;

namespace NorthWindProject.Application.Features.Account.Command.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<string>
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }

    public class
        ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand,
            string>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Handle(ConfirmEmailCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
                throw new ClientValidationException("Пользователь не найден");

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
                throw new ClientValidationException("Не удалось подтвердить аккаунт");

            await _signInManager.SignInAsync(user, true);

            return "Аккаунт подтвержден";
        }
    }
}