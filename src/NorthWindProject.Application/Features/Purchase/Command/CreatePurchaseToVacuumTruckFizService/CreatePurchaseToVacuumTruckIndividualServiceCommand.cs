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
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWindProject.Application.Features.ExportDocument.Query.ExportVacuumTruckPurchase;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Interfaces;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : BaseCreatePurchaseCommand, IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
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
        private readonly ICurrentUserService _currentUserService;

        private const string ServiceName = "Ассенизатор";

        public CreatePurchaseToVacuumTruckIndividualServiceCommandHandler(AppDbContext context,
            IEmailSenderService emailSenderService,
            IMediator mediator,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _emailSenderService = emailSenderService;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            var date = DateTime.Now;
            var currentUser = await _context.Users
                .SingleOrDefaultAsync(user => user.Id == _currentUserService.UserId, cancellationToken);
            

            var purchase = new VacuumTruckFizPurchase
            {
                Day = date.Day.ToString(),
                Month = date.Month.ToString(),
                Year = date.Year.ToString(),
                FullName = $"{request.Surname} {request.Name} {request.MiddleName}",
                PassportSerialNumber = request.PassportSerialNumber,
                PassportId = request.PassportId,
                PassportIssued = request.PassportIssued,
                PassportIssueDate = request.PassportIssueDate,
                DivisionCode = request.DivisionCode,
                TerritoryAddress = request.TerritoryAddress,
                RegistrationAddress = request.RegistrationAddress,
                Price = request.Price.ToString(CultureInfo.InvariantCulture),
                //todo реализовать
                PriceString = $"{request.Surname} {request.Name} {request.MiddleName}",
                PhoneNumber = request.PhoneNumber,
                ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate()
            };
            
            return Unit.Value;
        }

        // public async Task<Unit> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
        //     CancellationToken cancellationToken, 
        //     ICurrentUserService currentUserService)
        // {
        //     var date = DateTime.Now;
        //
        //     var currentUser = await _context.Users
        //         .SingleOrDefaultAsync(user => user.Id == _currentUserService.UserId, cancellationToken);
        //     
        //     
        //     
        //     var purchase = new VacuumTruckFizPurchase
        //     {
        //         
        //     }

        // var date = DateTime.Now;
        // var purchase = new VacuumTruckFizPurchase
        // {
        //     Day = date.Day.ToString(),
        //     Month = date.GetNumberOfMonthInDativeCase(),
        //     Year = date.Year.ToString(),
        //     FullName = $"{request.Surname} {request.Name} {request.MiddleName}",
        //     PassportSerialNumber = request.PassportSerialNumber,
        //     PassportId = request.PassportId,
        //     PassportIssued = request.PassportIssued,
        //     DivisionCode = request.DivisionCode,
        //     TerritoryAddress = request.TerritoryAddress,
        //     Price = request.Price.ToString(CultureInfo.InvariantCulture),
        //     RegistrationAddress = request.RegistrationAddress,
        //     PriceString = "Заполнение пока не реализовано",
        //     PhoneNumber = request.PhoneNumber,
        //     ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate()
        // };
        //
        // await _context.FizVacuumTruckPurchases.AddAsync(purchase, cancellationToken);
        //
        // var file = await _mediator.Send(new ExportVacuumTruckPurchaseQuery
        // {
        //     PurchaseId = purchase.Id
        // }, cancellationToken);
        //
        // _emailSenderService.SendEmailAsync(new EmailBodyModel
        // {
        //     ToEmail = request.Email,
        //     Username = "Здравствуйте!",
        //     Subject = "Подтверждение аккаунта",
        //     HtmlBody =
        //         $"<div>Договор</div>",
        //     Files = new List<FileModel> {file}, 
        // });

        //     return Unit.Value;
        // }
    }
}