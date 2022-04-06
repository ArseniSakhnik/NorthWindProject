using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService
{
    public class CreatePurchaseToVacuumTruckFizCommand : BaseCreatePurchaseCommand, IRequest
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
        CreatePurchaseToVacuumTruckFizCommandHandler : IRequestHandler<
            CreatePurchaseToVacuumTruckFizCommand>
    {
        private readonly IPurchaseService _purchaseService;

        public CreatePurchaseToVacuumTruckFizCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public async Task<Unit> Handle(CreatePurchaseToVacuumTruckFizCommand request,
            CancellationToken cancellationToken)
        {
            await _purchaseService.CreatePurchaseAsync(
                CreateVacuumTruckFizPurchase,
                request,
                ServicesEnum.АссенизаторФиз,
                cancellationToken);

            return Unit.Value;
        }

        private VacuumTruckFizPurchase CreateVacuumTruckFizPurchase(
            CreatePurchaseToVacuumTruckFizCommand request)
        {
            return new VacuumTruckFizPurchase
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
                PhoneNumber = request.PhoneNumber,
            };
        }
    }
}