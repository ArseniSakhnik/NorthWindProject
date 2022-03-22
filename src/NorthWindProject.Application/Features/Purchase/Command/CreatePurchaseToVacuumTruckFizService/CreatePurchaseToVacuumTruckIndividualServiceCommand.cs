using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWindProject.Application.Enums;
using NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase;
using NorthWindProject.Application.Features.Purchase.Events;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Features.Purchase.Command.CreatePurchaseToVacuumTruckFizService
{
    public class CreatePurchaseToVacuumTruckIndividualServiceCommand : BaseCreatePurchaseCommand, IRequest
    {
        //Серия паспорта
        public string PassportSerialNumber { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Номер паспорта
        public string PassportId { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Паспорт выдан
        public string PassportIssued { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Дата выдачи
        public string PassportIssueDate { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Код подразделения
        public string DivisionCode { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Адрес регистрации
        public string RegistrationAddress { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Адрес территории
        public string TerritoryAddress { get; set; } = "МЕСТО ДЛЯ ЗАПОЛНЕНИЯ";

        //Цена
        public double Price { get; set; }

        //ДоговорДействуетДо
        public DateTime ContractValidDate { get; set; }
    }

    public class
        CreatePurchaseToVacuumTruckIndividualServiceCommandHandler : IRequestHandler<
            CreatePurchaseToVacuumTruckIndividualServiceCommand>
    {
        private const string ServiceName = "Ассенизатор";
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IEncryptionService _encryptionService;

        public CreatePurchaseToVacuumTruckIndividualServiceCommandHandler(AppDbContext context,
            ICurrentUserService currentUserService,
            IEncryptionService encryptionService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _encryptionService = encryptionService;
        }

        public async Task<Unit> Handle(CreatePurchaseToVacuumTruckIndividualServiceCommand request,
            CancellationToken cancellationToken)
        {
            var date = DateTime.Now;

            var currentUser = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(user => user.Id == _currentUserService.UserId, cancellationToken);

            //todo пока что один сервис
            var service =
                await _context.Services
                    .AsNoTracking()
                    .Include(service => service.DocumentServices)
                    .SingleOrDefaultAsync(service => service.Id == ServicesEnum.АссенизаторФиз, cancellationToken);

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
                PriceString = "",
                PhoneNumber = request.PhoneNumber,
                ContractValidDate = request.ContractValidDate.GetFormattedToBlankDate(),

                UserId = currentUser.Id,
                ServiceId = service.Id,
                DocumentServiceId = service.DocumentServices.First().Id
            };

            purchase.EncryptObject(_encryptionService);
            purchase.DomainEvents.Add(new SendEmailPurchaseAlertEvent
            {
                Email = request.Email,
                Purchase = purchase,
            });
            currentUser.Purchases.Add(purchase);


            await _context.FizVacuumTruckPurchases.AddAsync(purchase, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}