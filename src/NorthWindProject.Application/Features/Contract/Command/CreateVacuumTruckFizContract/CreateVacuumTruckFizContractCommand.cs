using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.VacuumTruckFizContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckYurContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract
{
    public class CreateVacuumTruckFizContractCommand : BaseCreateFizContractCommand, IRequest
    {
    }

    public class
        CreateVacuumTruckFizContractCommandHandler : IRequestHandler<
            CreateVacuumTruckFizContractCommand>
    {
        private readonly IContractService _contractService;

        public CreateVacuumTruckFizContractCommandHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<Unit> Handle(CreateVacuumTruckFizContractCommand request,
            CancellationToken cancellationToken)
        {
            var contract = new VacuumTruckFizContract();

            _contractService.FillContract(request, contract);
            _contractService.FillFizContract(request, contract);

            await _contractService.CreateContractAsync(contract, ServiceViewEnum.КГО, cancellationToken);

            return Unit.Value;
        }
    }
}