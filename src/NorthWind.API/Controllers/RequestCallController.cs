using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.RequestCall.Command;
using NorthWindProject.Application.Features.RequestCall.Command.CreateRequestCall;
using NorthWindProject.Application.Features.RequestCall.Query;

namespace NorthWind.API.Controllers
{
    public class RequestCallController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRequestCalls([FromQuery] GetRequestCallsQuery query,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> CreateRequestCall(CreateRequestCallCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}