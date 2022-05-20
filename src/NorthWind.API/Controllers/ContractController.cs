using System.Threading;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract;
using NorthWindProject.Application.Features.Contract.Command.DeleteContract;
using NorthWindProject.Application.Features.Contract.Query.GetContract;
using NorthWindProject.Application.Features.Contract.Query.GetContracts;
using NorthWindProject.Application.Features.Contract.Query.GetUserContracts;

namespace NorthWind.API.Controllers
{
    public class ContractController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetContracts([FromQuery] GetContractsQuery query,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("{contractId:int}")]
        public async Task<IActionResult> GetPurchase(int contractId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetContractQuery
            {
                ContractId = contractId
            }, cancellationToken));

        [HttpGet("get-user-contracts")]
        public async Task<IActionResult> GetUserContracts(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetUserContractsQuery(), cancellationToken));

        [HttpPost("create-vacuum-truck-fiz-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckFizContract(
            CreateVacuumTruckFizContractCommand contractCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(contractCommand, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckYurContract(
            CreateVacuumTruckYurContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-yur-contract")]
        public async Task<IActionResult> CreateContractKgo(CreateKgoYurContractCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{contractId:int}")]
        public async Task<IActionResult> DeleteContract(int contractId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new DeleteContractCommand
            {
                Id = contractId
            }, cancellationToken));
    }
}