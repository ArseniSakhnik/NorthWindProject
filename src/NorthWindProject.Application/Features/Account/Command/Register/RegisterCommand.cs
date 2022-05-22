using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.Core.Entities.User;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Exceptions;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;
using NorthWindProject.Application.Common.Models;

namespace NorthWindProject.Application.Features.Account.Command.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandHandler(
            UserManager<ApplicationUser> userManager,
            IEmailSenderService emailSenderService,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailSenderService = emailSenderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Name = request.Name,
                Surname = request.Surname,
                MiddleName = request.MiddleName,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = $"{request.Surname} {request.Name} {request.MiddleName} ",
            };

            var password = CreatePassword();

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) throw new ClientValidationException("Не удалось зарегестрироваться");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var registerRequest = _httpContextAccessor.HttpContext.Request;
            //todo убрать решетку если потребуется
            var callbackUrl =
                $"{StringExtensions.GetCallbackUrl(registerRequest)}/#/confirm-email?userId={user.Id}&code={code}";

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = request.Email,
                Username = "Здравствуйте!",
                Subject = "Подтверждение аккаунта",
                HtmlBody =
                    $"<div>Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>" +
                    $"<div>Ваш пароль: {password}</div>"
            });

            await _userManager.AddToRoleAsync(user, "Client");
            // await _signInManager.SignInAsync(user, false);

            return "Для завершения регистрации подтвердите аккаунт на электронной почте";
        }


        private static string CreatePassword()
        {
            var rnd = new Random();

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();

            var length = rnd.Next(7, 10);

            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}