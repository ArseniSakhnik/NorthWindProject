using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Test.Commands;

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

        [HttpGet]
        public async Task<IActionResult> GetError()
        {
            throw new Exception("kal");
        }

        [HttpGet("validate-exception")]
        public async Task<IActionResult> GetValidateException()
        {
            return Ok(await Mediator.Send(new AddTestCommand()));
        }

        [HttpGet("success-message")]
        public async Task<IActionResult> Success()
        {
            return Ok("успешно");
        }

        [HttpGet("success-object")]
        public async Task<IActionResult> SuccsessObject()
        {
            return Ok(new {message = "Успешно"});
        }

        // [Authorize(Roles = "Admin")]
        // [HttpGet]
        // public IActionResult Test()
        // {
        //     return Ok(new {message = "ok"});
        // }
        //
        // [HttpPost]
        // public async Task<IActionResult> CreateTest(AddTestCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }
        //
        // [HttpPost("email")]
        // public async Task<IActionResult> TestEmail()
        // {
        //     return Ok(await Mediator.Send(new EmailTestCommand()));
        // }
        //
        // [HttpGet("health-check")]
        // public async Task<IActionResult> HealthCheck()
        // {
        //     return Ok();
        // }
        //
        // [HttpGet("db-health-check")]
        // public async Task<IActionResult> DbHealthCheck(CancellationToken cancellationToken)
        // {
        //     var a = await _dbContext.Users.FirstOrDefaultAsync(cancellationToken);
        //     return Ok(a);
        // }
    }
}