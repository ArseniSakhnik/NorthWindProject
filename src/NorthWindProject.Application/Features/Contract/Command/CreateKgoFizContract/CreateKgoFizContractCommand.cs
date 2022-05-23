using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.KgoFizContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateKgoFizContract
{
    public class CreateKgoFizContractCommand : BaseFizContractCommand, IRequest
    {
        public string Volume { get; set; }
        public string Overload { get; set; }
    }

    public class CreateKgoFizContractCommandHandler : IRequestHandler<CreateKgoFizContractCommand>
    {
        private readonly AppDbContext _context;
        private readonly IContractService _contractService;

        public CreateKgoFizContractCommandHandler(AppDbContext context, IContractService contractService)
        {
            _context = context;
            _contractService = contractService;
        }

        public async Task<Unit> Handle(CreateKgoFizContractCommand request, CancellationToken cancellationToken)
        {
            var kgoFizContract = new KGOFizContract();

            _contractService.FillContract(request, kgoFizContract);
            _contractService.FillFizContract(request, kgoFizContract);

            kgoFizContract.Volume = request.Volume;
            kgoFizContract.Overload = request.Overload;

            await _contractService.CreateContractAsync(
                kgoFizContract, 
                ServicesRequestTypeEnum.КГОФиз,
                cancellationToken);
            
            return Unit.Value;
        }
    }
}