using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

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

        public GetVacuumTruckYurContractQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<VacuumTruckYurContractDto> Handle(GetVacuumTruckYurContractQuery request,
            CancellationToken cancellationToken)
        {
            var contract = await _context.VacuumTruckYurContracts
                .SingleOrDefaultAsync(contract => contract.Id == request.ContractId, cancellationToken);

            contract.DecryptObject(_encryptionService);

            return new VacuumTruckYurContractDto
            {
                ClientShortName = contract.ClientShortName,
                PersonalNameEntrepreneur = contract.PersonalNameEntrepreneur,
                ActsOnBasis = contract.ActsOnBasis,
                TerritoryAddress = contract.TerritoryAddress,
                Price = contract.Price,
                OGRN = contract.OGRN,
                INN = contract.INN,
                KPP = contract.KPP,
                LegalAddress = contract.LegalAddress,
                PhoneNumber = contract.PhoneNumber
            };
        }
    }
}