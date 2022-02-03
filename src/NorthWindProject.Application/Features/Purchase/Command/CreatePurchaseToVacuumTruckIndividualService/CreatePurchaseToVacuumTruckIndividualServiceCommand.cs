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
using NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToAssenizatorIndividualService;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckIndividualService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : IRequest<PurchaseCreateResponseDto>
    {
        #region Пользовательские данные

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        #endregion

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
        CreatePurchaseToAssenizatorIndividualServiceCommandHandler
        : IRequestHandler<CreatePurchaseToVacuumTruckIndividualServiceCommand, PurchaseCreateResponseDto>
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private const string ServiceName = "Ассенизатор";

        public CreatePurchaseToAssenizatorIndividualServiceCommandHandler(IMediator mediator, AppDbContext context,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        public async Task<PurchaseCreateResponseDto> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            var userByEmailQuery = _context.Users
                .Include(user => user.Purchases)
                .Where(user => user.Email == request.Email)
                .AsQueryable();

            var userByEmail = await userByEmailQuery
                .SingleOrDefaultAsync(cancellationToken);

            var purchase = await CreatePurchase(request, cancellationToken);
            var response = new PurchaseCreateResponseDto();

            if (userByEmail is null)
            {
                var fileToConfirm =
                    await _mediator.Send(new ExportPurchaseQuery(ServiceName, purchase), cancellationToken);

                await _mediator.Send(new AutomaticCreateAccountCommand
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    FilesToConfirm = new List<FileModel> {fileToConfirm}
                }, cancellationToken);

                userByEmail = await userByEmailQuery.SingleOrDefaultAsync(cancellationToken);

                response.Message +=
                    $"Аккаунт был создан. Пожалуйста, подтвердите аккаунт по вашему адресу ${request.Email}\n";
            }


            userByEmail.Purchases.Add(purchase);
            await _context.SaveChangesAsync(cancellationToken);
            return response;
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