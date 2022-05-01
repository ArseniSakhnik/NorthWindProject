using System.Threading;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract;
using NorthWindProject.Application.Features.Contract.Query.GetContracts;
using NorthWindProject.Application.Features.Contract.Query.GetVacuumTruckFizContract;
using NorthWindProject.Application.Features.Contract.Query.GetVacuumTruckYurContract;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetContracts(DataSourceLoadOptions options,
            CancellationToken cancellationToken)
        {
            var query = await Mediator.Send(new GetContractsQuery(), cancellationToken);
            options.RequireTotalCount = true;
            return Ok(await DataSourceLoader.LoadAsync(query, options, cancellationToken));
        }

        [HttpGet("vacuum-truck-fiz-purchase/{purchaseId:int}")]
        public async Task<IActionResult> GetVacuumTruckFizPurchase(int purchaseId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVacuumTruckFizContractQuery
            {
                ContractId = purchaseId
            }, cancellationToken));
        }

        [HttpGet("vacuum-truck-yur-purchase/{purchaseId:int}")]
        public async Task<IActionResult> GetVacuumTruckYurPurchase(int purchaseId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVacuumTruckYurContractQuery
            {
                ContractId = purchaseId
            }, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-fiz-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckFizPurchase(
            CreateVacuumTruckYurContractCommand contractCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(contractCommand, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-purchase")]
        public async Task<IActionResult> CreatePurchaseToVacuumTruckYurPurchase(
            CreateVacuumTruckFizContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-yur-purchase")]
        public async Task<IActionResult> CreatePurchaseKgo(CreateKgoYurContractCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}