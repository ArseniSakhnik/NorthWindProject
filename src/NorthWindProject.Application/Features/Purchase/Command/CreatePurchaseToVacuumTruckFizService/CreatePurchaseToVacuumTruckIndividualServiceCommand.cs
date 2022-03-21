using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportVacuumTruckPurchase;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : BaseCreatePurchaseCommand, IRequest
    {
        //Серия паспорта
        public string PassportSerialNumber { get; set; }

        //Номер паспорта
        public string PassportId { get; set; }

        //Паспорт выдан
        public string PassportIssued { get; set; }

        //Код подразделения
        public string DivisionCode { get; set; }

        //Адрес регистрации
        public string RegistrationAddress { get; set; }

        //Адрес территории
        public string TerritoryAddress { get; set; }

        //Цена
        public double Price { get; set; }

        //ДоговорДействуетДо
        public DateTime ContractValidDate { get; set; }
    }

    public class
        CreatePurchaseToVacuumTruckIndividualServiceCommandHandler : IRequestHandler<
            CreatePurchaseToVacuumTruckIndividualServiceCommand>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly IEmailSenderService _emailSenderService;

        private const string ServiceName = "Ассенизатор";

        public CreatePurchaseToVacuumTruckIndividualServiceCommandHandler(AppDbContext context,
            IEmailSenderService emailSenderService,
            IMediator mediator)
        {
            _context = context;
            _emailSenderService = emailSenderService;
        }

        public async Task<Unit> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            var date = DateTime.Now;
            var purchase = new VacuumTruckFizPurchase
            {
                Day = date.Day.ToString(),
                Month = date.GetNumberOfMonthInDativeCase(),
                Year = date.Year.ToString(),
                FullName = $"{request.Surname} {request.Name} {request.MiddleName}",
                PassportSerialNumber = request.PassportSerialNumber,
                PassportId = request.PassportId,
                PassportIssued = request.PassportIssued,
                DivisionCode = request.DivisionCode,
                TerritoryAddress = request.TerritoryAddress,
                Price = request.Price.ToString(CultureInfo.InvariantCulture),
                RegistrationAddress = request.RegistrationAddress,
                PriceString = "Заполнение пока не реализовано",
                PhoneNumber = request.PhoneNumber,
                ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate()
            };

            await _context.FizVacuumTruckPurchases.AddAsync(purchase, cancellationToken);

            var file = await _mediator.Send(new ExportVacuumTruckPurchaseQuery
            {
                PurchaseId = purchase.Id
            }, cancellationToken);

            _emailSenderService.SendEmailAsync(new EmailBodyModel
            {
                ToEmail = request.Email,
                Username = "Здравствуйте!",
                Subject = "Подтверждение аккаунта",
                HtmlBody =
                    $"<div>Договор</div>",
                Files = new List<FileModel> {file}, 
            });
            
            return Unit.Value;
        }
    }
}