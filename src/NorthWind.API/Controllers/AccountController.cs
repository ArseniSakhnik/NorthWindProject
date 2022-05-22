using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Account.Command.ConfirmEmail;
using NorthWindProject.Application.Features.Account.Command.Login;
using NorthWindProject.Application.Features.Account.Command.Logout;
using NorthWindProject.Application.Features.Account.Command.Register;
using NorthWindProject.Application.Features.Account.Query.GetCurrentUserInfo;
using NorthWindProject.Application.Features.User.Command.AddUserRole;
using NorthWindProject.Application.Features.User.Query.GetUsers;

namespace NorthWind.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInfo(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCurrentUserInfoQuery(), cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetUsersAll([FromQuery] GetUsersQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
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
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("change-user-roles")]
        public async Task<IActionResult> ChangeUserRoles(ChangeUserRolesCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}