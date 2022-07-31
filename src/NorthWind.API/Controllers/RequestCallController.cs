using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.RequestCall;

namespace NorthWind.API.Controllers
{
    public class RequestCallController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateRequestCall(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new CreateRequestCallCommand(), cancellationToken));
    }
}