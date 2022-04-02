using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToKgo;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckYurPurchase;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpPost("create-vacuum-truck-fiz-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckFizPurchase(
            CreatePurchaseToVacuumTruckFizCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-individual-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckYurPurchase(
            CreatePurchaseToVacuumTruckYurPurchaseCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-yur-purchase")]
        public async Task<IActionResult> CreatePurchaseKgo(CreatePurchaseToKgoCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}