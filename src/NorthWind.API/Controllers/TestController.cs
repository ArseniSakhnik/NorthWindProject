using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Test.Commands;

namespace NorthWind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ApiController
    {
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new {message = "ok"});
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(AddTestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}