using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Query.GetVacuumTruckFizContract
{
    public class GetVacuumTruckFizContractQuery : IRequest<VacuumTruckFizContractDto>
    {
        public int ContractId { get; set; }
    }

    public class
        GetVacuumTruckFizContractQueryHandler : IRequestHandler<GetVacuumTruckFizContractQuery,
            VacuumTruckFizContractDto>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;
        private readonly IContractService _contractService;

        public GetVacuumTruckFizContractQueryHandler(AppDbContext context,
            IEncryptionService encryptionService,
            IContractService contractService)
        {
            _context = context;
            _encryptionService = encryptionService;
            _contractService = contractService;
        }

        public async Task<VacuumTruckFizContractDto> Handle(GetVacuumTruckFizContractQuery request,
            CancellationToken cancellationToken)
        {
            var contract = await _context.VacuumTruckFizContracts
                .Where(contract => contract.Id == request.ContractId)
                .SingleOrDefaultAsync(cancellationToken);

            if (contract is IEncryptObject encryptionContract)
            {
                encryptionContract.DecryptObject(_encryptionService);
            }

            var dto = new VacuumTruckFizContractDto();

            _contractService.FillContractDto(contract, dto);
            _contractService.FillFizContractDto(contract, dto);

            return dto;
        }
    }
}