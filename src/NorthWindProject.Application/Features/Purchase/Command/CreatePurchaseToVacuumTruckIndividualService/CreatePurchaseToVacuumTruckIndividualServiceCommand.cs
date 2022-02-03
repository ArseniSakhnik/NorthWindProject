using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchase;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Enums.VacuumTruckServiceEnums;
using NorthWindProject.Application.Features.Account.Command.AuthomaticCreateAccount;
using NorthWindProject.Application.Features.ExportDocument.Query;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchase;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckIndividualService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : BaseCreatePurchaseCommand, IRequest<PurchaseCreateResponseDto>
    {
        #region Данные для заявки

        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string PassportSerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssued { get; set; }
        public DateTime PassportIssueDate { get; set; }
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
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        private const string ServiceName = "Ассенизатор";

        public CreatePurchaseToVacuumTruckIndividualServiceCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PurchaseCreateResponseDto> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreatePurchaseCommand<CreatePurchaseToVacuumTruckIndividualServiceCommand>
            {
                Data = request,
                CreatePurchase = CreatePurchase,
                ServiceName = ServiceName
            }, cancellationToken);
        }


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
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.День].Id,
                        Value = data.Date.Day.ToString()
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.Месяц].Id,
                        Value = data.Date.GetNumberOfMonthInDativeCase(),
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.Год].Id,
                        Value = data.Date.Year.ToString()
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ФИО].Id,
                        Value = data.FullName
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортСерия].Id,
                        Value = data.PassportSerialNumber
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортНомер].Id,
                        Value = data.PassportNumber
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортВыдан].Id,
                        Value = data.PassportIssued
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортДатаВыдачи].Id,
                        Value = data.PassportIssueDate.GetFormattedToBlankDate()
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.АдресТерритории].Id,
                        Value = data.TerritoryAddress
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ПаспортКП].Id,
                        Value = data.PassportDivisionNumber
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.АдресРегистрации].Id,
                        Value = data.RegistrationAddress
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ЦенаЧисло].Id,
                        Value = data.PriceNumber.ToString(CultureInfo.InvariantCulture)
                    },
                    new FieldPurchase
                    {
                        FieldServiceId = fieldsDictionary[VacuumTruckServiceFieldsTypeEnum.ЦенаСтрока].Id,
                        Value = ""
                    }
                }
            };
        }
    }
}