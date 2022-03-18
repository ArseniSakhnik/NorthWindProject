using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterCommand : IRequest<RegisterResultDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResultDto>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

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
                Name = request.Name,
                Surname = request.Surname,
                MiddleName = request.MiddleName,
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
                    $"{StringExtensions.GetCallbackUrl(registerRequest)}/confirm-email?userId={user.Id}&code={code}";

                await _emailSenderService.SendEmailAsync(new EmailBodyModel
                {
                    ToEmail = request.Email,
                    Username = "Здравствуйте!",
                    Subject = "Подтверждение аккаунта",
                    HtmlBody =
                        $"<div>Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>"
                });

                await _userManager.AddToRoleAsync(user, RolesEnum.Client.ToString());
                // await _signInManager.SignInAsync(user, false);

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