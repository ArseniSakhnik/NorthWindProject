using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.ServiceView.Query.GetServiceViews;

namespace NorthWind.API.Controllers
{
    public class ServiceViewController : ApiController
    {
        private readonly IWebHostEnvironment _environment;

        public ServiceViewController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetServiceViews(CancellationToken cancellationToken)
        // {
        //     var response = await Mediator.Send(new GetServiceViewsQuery(), cancellationToken);
        //     return Ok(response);
        // }

        [HttpGet]
        public async Task<IActionResult> GetServiceViews(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetServiceViewsQuery(), cancellationToken));
    }
}