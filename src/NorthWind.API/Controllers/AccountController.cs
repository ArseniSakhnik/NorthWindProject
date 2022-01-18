using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.API.Models;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IEmailSenderService emailSenderService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSenderService = emailSenderService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                loginModel.Password,
                loginModel.RememberMe,
                true);

            if (result.Succeeded) return Ok();

            if (result.IsNotAllowed) return BadRequest("Аккаунт не подтвержден");

            return BadRequest("Неверное имя пользователя или пароль");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.Email,
                Email = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var request = HttpContext.Request;
                var callbackUrl = $"{request.Scheme}://{request.Host.Value}/confirm-email?userId={user.Id}&code={code}";

                await _emailSenderService.SendEmailAsync(registerModel.Email,
                    "Здравствуйте!",
                    "Подтверждение аккаунта",
                    $"<div>Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтверждение регистрации</a></div>");

                await _userManager.AddToRoleAsync(user, RolesEnum.Client.ToString());
                await _signInManager.SignInAsync(user, false);

                return Ok("Для завершения регистрации подтвердите аккаунт на электронной почте");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Вы вышли из системы");
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
        {
            if (confirmEmailModel.UserId == null || confirmEmailModel.Code == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(confirmEmailModel.UserId);

            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmailModel.Code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result.Succeeded ? (IActionResult) Ok() : BadRequest(result.Errors);
        }
    }
}