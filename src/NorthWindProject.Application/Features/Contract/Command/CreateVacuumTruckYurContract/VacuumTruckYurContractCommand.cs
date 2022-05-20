using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.VacuumTruckYurContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract
{
    public class VacuumTruckYurContractCommand : BaseYurContractCommand, IRequest
    {
    }

    public class
        CreateVacuumTruckYurContractCommandHandler : IRequestHandler<
            VacuumTruckYurContractCommand>
    {
        private readonly IContractService _contractService;

        public CreateVacuumTruckYurContractCommandHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<Unit> Handle(VacuumTruckYurContractCommand request,
            CancellationToken cancellationToken)
        {
            var contract = new VacuumTruckYurContract();

            _contractService.FillContract(request, contract);
            _contractService.FillYurContract(request, contract);

            await _contractService.CreateContractAsync(contract,
                ServicesRequestTypeEnum.АссенизаторЮр,
                cancellationToken);

            return Unit.Value;
        }
    }
}