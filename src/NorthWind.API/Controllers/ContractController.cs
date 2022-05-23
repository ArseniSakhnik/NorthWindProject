using System.Threading;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Contract.Command.ConfirmContract;
using NorthWindProject.Application.Features.Contract.Command.CreateKgoFizContract;
using NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract;
using NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract;
using NorthWindProject.Application.Features.Contract.Command.DeleteContract;
using NorthWindProject.Application.Features.Contract.Command.UpdateKgoYurContract;
using NorthWindProject.Application.Features.Contract.Command.UpdateVacuumTruckFizContract;
using NorthWindProject.Application.Features.Contract.Command.UpdateVacuumTruckYurContract;
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

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmContract(ConfirmContractCommand command,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(command, cancellationToken));

        [HttpPost("create-vacuum-truck-fiz-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckFizContract(
            VacuumTruckFizContractCommand contractCommand, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(contractCommand, cancellationToken));
        }

        [HttpPost("create-vacuum-truck-yur-contract")]
        public async Task<IActionResult> CreateContractToVacuumTruckYurContract(
            VacuumTruckYurContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-yur-contract")]
        public async Task<IActionResult> CreateContractKgo(KgoYurContractCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost("create-kgo-fiz-contract")]
        public async Task<IActionResult> CreateKgoFizContract(CreateKgoFizContractCommand command,
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("update-vacuum-truck-fiz-contract")]
        public async Task<IActionResult> UpdateContractToVacuumTruckFizContract(
            UpdateVacuumTruckFizContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("update-vacuum-truck-yur-contract")]
        public async Task<IActionResult> UpdateContractToVacuumTruckYurContract(
            UpdateVacuumTruckYurContractCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("update-kgo-yur-contract")]
        public async Task<IActionResult> UpdateContractKgo(UpdateKgoYurContractCommand command,
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