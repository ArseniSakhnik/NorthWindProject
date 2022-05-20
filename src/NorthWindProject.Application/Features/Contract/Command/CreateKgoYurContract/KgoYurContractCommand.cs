using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.KgoYurContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract
{
    public class KgoYurContractCommand : BaseYurContractCommand, IRequest
    {
        public string Volume { get; set; }
        public string Overload { get; set; }
    }

    public class CreateKgoYurContractCommandHandler : IRequestHandler<KgoYurContractCommand>
    {
        private readonly IContractService _contractService;

        public CreateKgoYurContractCommandHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<Unit> Handle(KgoYurContractCommand request, CancellationToken cancellationToken)
        {
            var kgoContract = new KGOYurContract();

            _contractService.FillContract(request, kgoContract);
            _contractService.FillYurContract(request, kgoContract);

            kgoContract.Volume = request.Volume;
            kgoContract.Overload = request.Overload;

            await _contractService.CreateContractAsync(kgoContract,
                ServicesRequestTypeEnum.КГОЮр,
                cancellationToken);

            return Unit.Value;
        }
    }
}