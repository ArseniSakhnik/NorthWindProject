using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.CreateAssenizatorPurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreateKGO;
using NorthWindProject.Application.Features.Purchase.Query.GetPurchases;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPurchase(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetPurchasesQuery(), cancellationToken));

        [HttpPost("assenizator")]
        public async Task<IActionResult> CreateAssenizator(CreateAssenizatorPurchaseCommandCommand commandCommand,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(commandCommand, cancellationToken));

        [HttpPost("kgo")]
        public async Task<IActionResult> CreateKGO(CreateKGOCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}