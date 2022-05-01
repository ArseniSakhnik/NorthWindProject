using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.KgoYurContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Features.Contract.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateKgoYurContract
{
    public class CreateKgoYurContractCommand : BaseCreateContractCommand, IRequest
    {
        public string FullNameClient { get; set; }
        public ActEnum ActOnTheBasis { get; set; }
        public string Volume { get; set; }
        public string TerritoryAddress { get; set; }
        public string MachineReload { get; set; }
        public double CoastPrice { get; set; }
        public DateTime ContractValidDate { get; set; }
        public double Price { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string OKPO { get; set; }
        public string LegalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientCompany { get; set; }
        public string CustomerContactPersonAndJobTitle { get; set; }
        public string PhoneNumberOrFax { get; set; }
        public int VehiclesNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class CreateKgoYurContractCommandHandler : IRequestHandler<CreateKgoYurContractCommand>
    {
        private readonly IContractService _contractService;

        public CreateKgoYurContractCommandHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<Unit> Handle(CreateKgoYurContractCommand request, CancellationToken cancellationToken)
        {
            await _contractService.CreateContractAsync(CreateKGOContract, request, ServicesEnum.КГОЮр,
                cancellationToken);

            return Unit.Value;
        }

        private KGOYurContract CreateKGOContract(CreateKgoYurContractCommand request)
        {
            return new KGOYurContract
            {
                FullNameClient = request.FullNameClient,
                //TODO Реализовать
                ActOnTheBasis = "Устава",
                Volume = request.Volume,
                TerritoryAddress = request.TerritoryAddress,
                MachineReload = request.MachineReload,
                CoastPrice = request.CoastPrice.ToString(CultureInfo.InvariantCulture),
                //todo реализовать
                CoastPriceString = "",
                ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate(),
                Price = request.Price == 0
                    ? null
                    : request.Price.ToString(CultureInfo.InvariantCulture),
                //todo реализовать
                PriceString = "",
                INN = request.INN,
                KPP = request.KPP,
                OGRN = request.OGRN,
                OKPO = request.OKPO,
                LegalAddress = request.LegalAddress,
                PhoneNumber = request.PhoneNumber,
                //todo реализовать
                ShortNameClient = "",
                ClientCompany = request.ClientCompany,
                CustomerContactPersonAndJobTitle = request.CustomerContactPersonAndJobTitle,
                PhoneNumberOrFax = request.PhoneNumberOrFax,
                VehiclesNumber = request.VehiclesNumber.ToString(),
                StartDate = request.StartDate.GetFormattedToBlankDate(),
                EndDate = request.EndDate.GetFormattedToBlankDate(),
                StartTime = request.StartTime.GetFormattedToBlankDate(),
                EndTime = request.EndTime.GetFormattedToBlankDate()
            };
        }
    }
}