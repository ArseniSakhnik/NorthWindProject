using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NorthWind.API.Models;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Account.Command.ConfirmEmailAndPurchases;
using NorthWindProject.Application.Features.Account.Command.Login;
using NorthWindProject.Application.Features.Account.Command.Register;
using NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInfo(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetCurrentUserInfoQuery(), cancellationToken));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsSucceed) return Ok();

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsSucceed) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Вы вышли из системы");
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailAndPurchasesCommand command,
            CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (!result.IsSucceed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}