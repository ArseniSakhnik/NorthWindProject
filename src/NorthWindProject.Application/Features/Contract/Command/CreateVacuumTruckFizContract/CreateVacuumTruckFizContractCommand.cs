using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.VacuumTruckYurContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Features.Contract.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckFizContract
{
    public class CreateVacuumTruckFizContractCommand : BaseCreateContractCommand, IRequest
    {
        public string ClientShortName { get; set; }
        public string PersonalNameEntrepreneur { get; set; }
        public string ActsOnBasis { get; set; }
        public string TerritoryAddress { get; set; }
        public double Price { get; set; }
        public string OGRN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string LegalAddress { get; set; }
        public string PhoneNumber { get; set; }
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
            await _contractService.CreateContractAsync(
                CreateVacuumTruckYurContract,
                request,
                ServicesEnum.АссенизаторЮр,
                cancellationToken);

            return Unit.Value;
        }

        private VacuumTruckYurContract CreateVacuumTruckYurContract(
            CreateVacuumTruckFizContractCommand request)
        {
            return new VacuumTruckYurContract
            {
                ClientShortName = request.ClientShortName,
                PersonalNameEntrepreneur = request.PersonalNameEntrepreneur,
                ActsOnBasis = "Устава",
                TerritoryAddress = request.TerritoryAddress,
                Price = request.Price == 0
                    ? null
                    : request.Price.ToString(CultureInfo.InvariantCulture),
                PriceString = "",
                OGRN = request.OGRN,
                INN = request.INN,
                KPP = request.KPP,
                LegalAddress = request.LegalAddress,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}