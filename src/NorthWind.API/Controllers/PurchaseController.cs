using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.ApprovePurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreateAssenizatorPurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreateKGO;
using NorthWindProject.Application.Features.Purchase.Command.RemovePurchase;
using NorthWindProject.Application.Features.Purchase.Command.UpdateAssenizator;
using NorthWindProject.Application.Features.Purchase.Command.UpdateKGO;
using NorthWindProject.Application.Features.Purchase.Query.GetAllPurchases;
using NorthWindProject.Application.Features.Purchase.Query.GetPages;
using NorthWindProject.Application.Features.Purchase.Query.GetPurchase;
using NorthWindProject.Application.Features.Purchase.Query.GetUserPurchases;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPurchases(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetUserPurchasesQuery(), cancellationToken));

        [HttpGet("{purchaseId:int}")]
        public async Task<IActionResult> GetPurchase(int purchaseId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetPurchaseQuery
            {
                PurchaseId = purchaseId
            }, cancellationToken));

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllPurchases([FromQuery] GetAllPurchasesQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));

        [HttpPost("assenizator")]
        public async Task<IActionResult> CreateAssenizator(AssenizatorPurchaseCommandCommand commandCommand,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(commandCommand, cancellationToken));

        [HttpPost("kgo")]
        public async Task<IActionResult> CreateKGO(KgoCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpPut("assenizator")]
        public async Task<IActionResult> UpdateAssenizator(UpdateAssenizatorCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpPut("confirm")]
        public async Task<IActionResult> ApprovePurchase(ConfirmPurchaseCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpPut("kgo")]
        public async Task<IActionResult> UpdateKGO(UpdateKGOCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpDelete("{purchaseId:int}")]
        public async Task<IActionResult> RemovePurchase(int purchaseId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new RemovePurchaseCommand
            {
                PurchaseId = purchaseId
            }, cancellationToken));
    }
}