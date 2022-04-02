using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Account.Command.ConfirmEmail;
using NorthWindProject.Application.Features.Account.Command.Login;
using NorthWindProject.Application.Features.Account.Command.Logout;
using NorthWindProject.Application.Features.Account.Command.Register;
using NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInfo(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrentUserInfoQuery(), cancellationToken));
        }

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

            if (result.IsSucceed) return Ok();

            return BadRequest(result.Message);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailCommand command,
            CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (!result.IsSucceed)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}