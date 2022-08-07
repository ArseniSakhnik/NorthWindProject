using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.RequestCall;
using NorthWindProject.Application.Features.RequestCall.Command;
using NorthWindProject.Application.Features.RequestCall.Command.CreateRequestCall;

namespace NorthWind.API.Controllers
{
    public class RequestCallController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateRequestCall(CreateRequestCallCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}