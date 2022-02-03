using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckIndividualService;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpPost("create-assenizator-individual-purchase")]
        public async Task<IActionResult> CreatePurchaseToAssenizatorIndividualService(
            CreatePurchaseToVacuumTruckIndividualServiceCommand command, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));
    }
}