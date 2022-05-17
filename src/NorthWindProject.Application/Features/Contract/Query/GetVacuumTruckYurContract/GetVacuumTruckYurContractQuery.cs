using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Query.GetVacuumTruckYurContract
{
    public class GetVacuumTruckYurContractQuery : IRequest<VacuumTruckYurContractDto>
    {
        public int ContractId { get; set; }
    }

    public class
        GetVacuumTruckYurContractQueryHandler : IRequestHandler<GetVacuumTruckYurContractQuery,
            VacuumTruckYurContractDto>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;
        private readonly IContractService _contractService;

        public GetVacuumTruckYurContractQueryHandler(AppDbContext context,
            IEncryptionService encryptionService,
            IContractService contractService)
        {
            _context = context;
            _encryptionService = encryptionService;
            _contractService = contractService;
        }

        public async Task<VacuumTruckYurContractDto> Handle(GetVacuumTruckYurContractQuery request,
            CancellationToken cancellationToken)
        {
            var contract = await _context.VacuumTruckYurContracts
                .SingleOrDefaultAsync(contract => contract.Id == request.ContractId, cancellationToken);

            contract.DecryptObject(_encryptionService);

            var dto = new VacuumTruckYurContractDto();

            _contractService.FillContractDto(contract, dto);
            _contractService.FillYurContractDto(contract, dto);

            return dto;
        }
    }
}