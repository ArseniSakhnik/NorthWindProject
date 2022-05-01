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
    public class ContractController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetContracts(DataSourceLoadOptions options,
            CancellationToken cancellationToken)
        {
            var query = await Mediator.Send(new GetContractsQuery(), cancellationToken);
            options.RequireTotalCount = true;
            return Ok(await DataSourceLoader.LoadAsync(query, options, cancellationToken));
        }

        [HttpGet("vacuum-truck-fiz-contract/{contractId:int}")]
        public async Task<IActionResult> GetVacuumTruckFizContract(int contractId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVacuumTruckFizContractQuery
            {
                ContractId = contractId
            }, cancellationToken));
        }

        [HttpGet("vacuum-truck-yur-contract/{contractId:int}")]
        public async Task<IActionResult> GetVacuumTruckYurContract(int contractId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetVacuumTruckYurContractQuery
            {
                ContractId = contractId
            }, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-fiz-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckFizContract(
            CreateVacuumTruckYurContractCommand contractCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(contractCommand, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckYurContract(
            CreateVacuumTruckFizContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-yur-contract")]
        public async Task<IActionResult> CreateContractKgo(CreateKgoYurContractCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}