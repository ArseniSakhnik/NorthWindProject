using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.CreateAssenizatorPurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreateKGO;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpPost("assenizator")]
        public async Task<IActionResult> CreateAssenizator(CreateAssenizatorPurchaseCommandCommand commandCommand,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(commandCommand, cancellationToken));

        [HttpPost("kgo")]
        public async Task<IActionResult> CreateKGO(CreateKGOCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}