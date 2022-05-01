using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

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

        public GetVacuumTruckFizContractQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<VacuumTruckFizContractDto> Handle(GetVacuumTruckFizContractQuery request,
            CancellationToken cancellationToken)
        {
            var contract = await _context.VacuumTruckFizContracts
                .Where(contract => contract.Id == request.ContractId)
                .SingleOrDefaultAsync(cancellationToken);

            contract.EncryptObject(_encryptionService);

            return new VacuumTruckFizContractDto
            {
                PassportSerialNumber = contract.PassportSerialNumber,
                PassportId = contract.PassportId,
                PassportIssued = contract.PassportIssued,
                PassportIssueDate = contract.PassportIssueDate,
                DivisionCode = contract.DivisionCode,
                RegistrationAddress = contract.RegistrationAddress,
                TerritoryAddress = contract.TerritoryAddress,
                Price = contract.Price
            };
        }
    }
}