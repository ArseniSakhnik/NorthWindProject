using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorthWind.API.Models;
using NorthWindProject.Application.Entities.User;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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

        // [HttpPost("register")]
        // public async Task<IActionResult> Register(RegisterModel registerModel)
        // {
        //     var user = new ApplicationUser
        //     {
        //         UserName = registerModel.Email,
        //         Email = registerModel.Email
        //     };
        //
        //     var result = await _userManager.CreateAsync(user, registerModel.Password);
        //
        //     if (result.Succeeded)
        //     {
        //         var code = await _userManager
        //     }
        // }
    }
}