using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Test.Commands;
using NorthWindProject.Application.Features.UploadBasicServices.UploadAssenizatorService;
using NorthWindProject.Application.Interfaces;

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

        [HttpPost("email")]
        public async Task<IActionResult> TestEmail()
        {
            return Ok(await Mediator.Send(new EmailTestCommand()));
        }


        [HttpPost("upload-assenizator-service")]
        public async Task<IActionResult> UploadAssenizatorService(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new UploadAssenizatorServiceCommand
            {
                File = Request.Form.Files.SingleOrDefault()
            }, cancellationToken));
    }
}