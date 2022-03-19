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
using NorthWindProject.Application.Features.Account.Command.Logout;
using NorthWindProject.Application.Features.Account.Command.Register;
using NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInfo(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetCurrentUserInfoQuery(), cancellationToken));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsSucceed) return Ok();

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsSucceed) return Ok();

            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailAndPurchasesCommand command,
            CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            if (!result.IsSucceed)
                return BadRequest();

            return Ok();
        }
    }
}