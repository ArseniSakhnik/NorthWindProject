using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckYurPurchase
{
    public class CreatePurchaseToVacuumTruckYurPurchaseCommand : BaseCreatePurchaseCommand, IRequest
    {
        public string IndividualEntrepreneurShortName { get; set; }
        public ActEnum Act { get; set; }
        public string TerritoryAddress { get; set; }
        public double Price { get; set; }
        public DateTime ContractValidDate { get; set; }
        public string OGRN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string LegalAddress { get; set; }

    }

    public class
        CreatePurchaseToVacuumTruckYurPurchaseCommandHandler : IRequestHandler<
            CreatePurchaseToVacuumTruckYurPurchaseCommand>
    {
        private readonly IPurchaseService _purchaseService;

        public CreatePurchaseToVacuumTruckYurPurchaseCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public async Task<Unit> Handle(CreatePurchaseToVacuumTruckYurPurchaseCommand request,
            CancellationToken cancellationToken)
        {
            await _purchaseService.CreatePurchaseAsync(
                CreateVacuumTruckYurPurchase, 
                request,
                ServicesEnum.АссенизаторЮр, 
                cancellationToken);
            
            return Unit.Value;
        }

        private VacuumTruckYurPurchase CreateVacuumTruckYurPurchase(
            CreatePurchaseToVacuumTruckYurPurchaseCommand request)
        {
            return new VacuumTruckYurPurchase
            {
                IndividualEntrepreneurShortName = request.IndividualEntrepreneurShortName,
                FullNameClient = $"{request.Surname} {request.Name} {request.MiddleName}",
                ActOnTheBasis = "Устава",
                TerritoryAddress = request.TerritoryAddress,
                Price = request.Price.ToString(CultureInfo.InvariantCulture),
                PriceString = "Не реализовано",
                ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate(),
                OGRN = request.OGRN,
                INN = request.INN,
                KPP = request.KPP,
                LegalAddress = request.LegalAddress,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };
        }
    }
}