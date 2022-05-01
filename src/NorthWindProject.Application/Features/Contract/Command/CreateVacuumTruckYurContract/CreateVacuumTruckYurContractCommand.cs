using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Contracts.VacuumTruckFizContract;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Contract.Command.BaseCreateContract;
using NorthWindProject.Application.Features.Contract.Services.ContractService;

namespace NorthWindProject.Application.Features.Contract.Command.CreateVacuumTruckYurContract
{
    public class CreateVacuumTruckYurContractCommand : BaseCreateContractCommand, IRequest
    {
        //Серия паспорта
        public string PassportSerialNumber { get; set; }

        //Номер паспорта
        public string PassportId { get; set; }

        //Паспорт выдан
        public string PassportIssued { get; set; }

        //Дата выдачи
        public string PassportIssueDate { get; set; }

        //Код подразделения
        public string DivisionCode { get; set; }

        //Адрес регистрации
        public string RegistrationAddress { get; set; }

        //Адрес территории
        public string TerritoryAddress { get; set; }

        //Цена
        public double Price { get; set; }
    }

    public class
        CreateVacuumTruckYurContractCommandHandler : IRequestHandler<
            CreateVacuumTruckYurContractCommand>
    {
        private readonly IContractService _contractService;

        public CreateVacuumTruckYurContractCommandHandler(IContractService contractService)
        {
            _contractService = contractService;
        }

        public async Task<Unit> Handle(CreateVacuumTruckYurContractCommand request,
            CancellationToken cancellationToken)
        {
            await _contractService.CreateContractAsync(
                CreateVacuumTruckFizContract,
                request,
                ServicesEnum.АссенизаторФиз,
                cancellationToken);

            return Unit.Value;
        }

        private VacuumTruckFizContract CreateVacuumTruckFizContract(
            CreateVacuumTruckYurContractCommand request)
        {
            return new VacuumTruckFizContract
            {
                FullName = $"{request.Surname} {request.Name} {request.MiddleName}",
                PassportSerialNumber = request.PassportSerialNumber,
                PassportId = request.PassportId,
                PassportIssued = request.PassportIssued,
                PassportIssueDate = request.PassportIssueDate,
                DivisionCode = request.DivisionCode,
                TerritoryAddress = request.TerritoryAddress,
                RegistrationAddress = request.RegistrationAddress,
                Price = request.Price == 0
                    ? null
                    : request.Price.ToString(CultureInfo.InvariantCulture),
                //todo реализовать
                PriceString = "",
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}