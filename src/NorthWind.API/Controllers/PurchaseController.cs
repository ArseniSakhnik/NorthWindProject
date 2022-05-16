using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.CreateAssenizatorPurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreateKGO;
using NorthWindProject.Application.Features.Purchase.Query.GetPurchase;
using NorthWindProject.Application.Features.Purchase.Query.GetPurchases;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPurchases(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetPurchasesQuery(), cancellationToken));

        [HttpGet("{purchaseId:int}")]
        public async Task<IActionResult> GetPurchase(int purchaseId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetPurchaseQuery
            {
                PurchaseId = purchaseId
            }, cancellationToken));

        [HttpPost("assenizator")]
        public async Task<IActionResult> CreateAssenizator(CreateAssenizatorPurchaseCommandCommand commandCommand,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(commandCommand, cancellationToken));

        [HttpPost("kgo")]
        public async Task<IActionResult> CreateKGO(CreateKGOCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}