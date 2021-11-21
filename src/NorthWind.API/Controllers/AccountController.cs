using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorthWind.API.Models;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Account.Command.Register;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginModel.UserName,
                loginModel.Password,
                loginModel.RememberMe,
                false);

            if (result.Succeeded) return Ok();


            return BadRequest("Неверное имя пользователя или пароль");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            
            if (result.Succeeded) return Ok();
            
            return BadRequest(result.Errors);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Вы вышли из системы");
        }
    }
}