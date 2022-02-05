using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Enums.VacuumTruckServiceEnums;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Services.PurchaseService;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckIndividualService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : BaseCreatePurchaseCommand,
        IRequest<PurchaseCreateResponseDto>
    {
        #region Данные для заявки

        public DateTime Date { get; set; } = DateTime.Now;
        public string FullName { get; set; }
        public string PassportSerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssued { get; set; }
        public DateTime PassportIssueDate { get; set; } = DateTime.Now;
        public string TerritoryAddress { get; set; }
        public string PassportDivisionNumber { get; set; }
        public string RegistrationAddress { get; set; }

        public double PriceNumber { get; set; }
        // public string PriceString { get; set; }

        #endregion
    }

    public class
        CreatePurchaseToVacuumTruckIndividualServiceCommandHandler
        : IRequestHandler<CreatePurchaseToVacuumTruckIndividualServiceCommand, PurchaseCreateResponseDto>
    {
        private const string ServiceName = "Ассенизатор";
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPurchaseService _purchaseService;

        public CreatePurchaseToVacuumTruckIndividualServiceCommandHandler(IMediator mediator, AppDbContext context,
            IPurchaseService purchaseService)
        {
            _mediator = mediator;
            _context = context;
            _purchaseService = purchaseService;
        }

        public async Task<PurchaseCreateResponseDto> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
            => await _purchaseService.CreateService(ServiceName, request, CreatePurchase, cancellationToken);


        private async Task<Entities.Purchase.Purchase> CreatePurchase(
            CreatePurchaseToVacuumTruckIndividualServiceCommand data, CancellationToken cancellationToken)
        {
            var vacuumTruckService = await _context.Services
                .Include(service => service.DocumentServices)
                .ThenInclude(service => service.FieldServices)
                .Where(service => service.Id == (int) ServicesEnum.Ассенизатор)
                .SingleOrDefaultAsync(cancellationToken);

            var documentService = vacuumTruckService.DocumentServices
                .SingleOrDefault();

            var fieldsDictionary = documentService.FieldServices
                .ToDictionary(field => field.FieldTypeId, field => field);

            return new Entities.Purchase.Purchase
            {
                ServiceId = vacuumTruckService.Id,
                Service = vacuumTruckService,
                IsConfirmed = false,
                Fields = new List<FieldPurchase>
                {
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.День].Id,
                        Value = data.Date.Day.ToString()
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.Месяц].Id,
                        Value = data.Date.GetNumberOfMonthInDativeCase()
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.Год].Id,
                        Value = data.Date.Year.ToString()
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ФИО].Id,
                        Value = data.FullName
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортСерия].Id,
                        Value = data.PassportSerialNumber
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортНомер].Id,
                        Value = data.PassportNumber
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортВыдан].Id,
                        Value = data.PassportIssued
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортДатаВыдачи].Id,
                        Value = data.PassportIssueDate.GetFormattedToBlankDate()
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.АдресТерритории].Id,
                        Value = data.TerritoryAddress
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортКП].Id,
                        Value = data.PassportDivisionNumber
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.АдресРегистрации].Id,
                        Value = data.RegistrationAddress
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ЦенаЧисло].Id,
                        Value = data.PriceNumber.ToString(CultureInfo.InvariantCulture)
                    },
                    new()
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ЦенаСтрока].Id,
                        Value = ""
                    }
                }
            };
        }
    }
}