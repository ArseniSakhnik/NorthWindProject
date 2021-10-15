using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Services.Commands;
using NorthWindProject.Application.Features.Services.Queries;

namespace NorthWind.API.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            return Ok(await Mediator.Send(new GetServicesCommand()));
        }

        [Authorize]
        [HttpPost("create-service")]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
    }
}