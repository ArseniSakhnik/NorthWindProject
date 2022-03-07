using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Test.Commands;
using NorthWindProject.Application.Interfaces;

namespace NorthWind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ApiController
    {

        private readonly AppDbContext _dbContext;

        public TestController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        [HttpPost("email")]
        public async Task<IActionResult> TestEmail()
        {
            return Ok(await Mediator.Send(new EmailTestCommand()));
        }

        [HttpGet("health-check")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok();
        }

        [HttpGet("db-health-check")]
        public async Task<IActionResult> DbHealthCheck(CancellationToken cancellationToken)
        {
            var a = await _dbContext.Users.FirstOrDefaultAsync(cancellationToken);
            return Ok(a);
        }
    }
}