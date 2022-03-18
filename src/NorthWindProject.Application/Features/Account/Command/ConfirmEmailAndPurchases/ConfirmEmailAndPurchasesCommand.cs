using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Features.Account.Command.ConfirmEmailAndPurchases
{
    public class ConfirmEmailAndPurchasesCommand : IRequest<ConfirmEmailAndPurchasesDto>
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }

    public class
        ConfirmEmailAndPurchasesCommandHandler : IRequestHandler<ConfirmEmailAndPurchasesCommand,
            ConfirmEmailAndPurchasesDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ConfirmEmailAndPurchasesCommandHandler(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ConfirmEmailAndPurchasesDto> Handle(ConfirmEmailAndPurchasesCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
            {
                return new ConfirmEmailAndPurchasesDto
                {
                    IsSucceed = false,
                    Message = "Пользователь не найден"
                };
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (!result.Succeeded)
                return new ConfirmEmailAndPurchasesDto
                {
                    IsSucceed = false,
                    Message = "Аккаунт подтвержден"
                };

            await _signInManager.SignInAsync(user, true);

            return new ConfirmEmailAndPurchasesDto
            {
                IsSucceed = true,
                Message = "Не удалось подтвердить аккаунт"
            };
        }
    }
}