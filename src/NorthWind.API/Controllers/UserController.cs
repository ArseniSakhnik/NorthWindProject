using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.User.Queries.GetCurrentUserQuery;

namespace NorthWind.API.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Ok(await Mediator.Send(new GetCurrentUserQuery()));
            }

            return Ok();
        }
    }
}