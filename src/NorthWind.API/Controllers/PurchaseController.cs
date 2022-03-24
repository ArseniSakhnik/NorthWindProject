using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckYurPurchase;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpPost("create-vacuum-truck-fiz-individual-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckFizPurchase(
            CreatePurchaseToVacuumTruckFizCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpPost("create-vacuum-truck-yur-individual-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckYurPurchase(
            CreatePurchaseToVacuumTruckYurPurchaseCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}