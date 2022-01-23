using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterCommand : IRequest<RegisterResultDto>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResultDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IEmailSenderService emailSenderService,
            SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RegisterResultDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var registerRequest = _httpContextAccessor.HttpContext.Request;
                var callbackUrl =
                    $"{registerRequest.Scheme}://{registerRequest.Host.Value}/confirm-email?userId={user.Id}&code={code}";

                await _emailSenderService.SendEmailAsync(request.Email,
                    "Здравствуйте!",
                    "Подтверждение аккаунта",
                    $"<div>Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>");

                await _userManager.AddToRoleAsync(user, RolesEnum.Client.ToString());
                await _signInManager.SignInAsync(user, false);

                return new RegisterResultDto
                {
                    IsSucceed = true,
                    Message = "Для завершения регистрации подтвердите аккаунт на электронной почте"
                };
            }

            return new RegisterResultDto
            {
                IsSucceed = false,
                Errors = result.Errors
            };
        }
    }
}