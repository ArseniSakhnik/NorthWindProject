using System.Threading;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToKgo;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckYurPurchase;
using NorthWindProject.Application.Features.Purchase.Query.GetPurchases;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPurchases(DataSourceLoadOptions options,
            CancellationToken cancellationToken)
        {
            var query = await Mediator.Send(new GetPurchasesQuery(), cancellationToken);
            options.RequireTotalCount = true;
            return Ok(await DataSourceLoader.LoadAsync(query, options, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-fiz-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckFizPurchase(
            CreatePurchaseToVacuumTruckFizCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-purchase")]
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