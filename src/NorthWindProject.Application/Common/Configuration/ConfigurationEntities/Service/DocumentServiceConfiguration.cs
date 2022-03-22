using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class
        DocumentServiceConfiguration : IEntityTypeConfiguration<Entities.Services.DocumentService.DocumentService>
    {
        public void Configure(EntityTypeBuilder<Entities.Services.DocumentService.DocumentService> builder)
        {
            builder
                .HasMany(service => service.Purchases)
                .WithOne(purchase => purchase.DocumentService)
                .HasForeignKey(purchase => purchase.DocumentServiceId);

            builder
                .Property(e => e.DocumentFields)
                .HasJsonConversion();

            builder.HasData(new List<Entities.Services.DocumentService.DocumentService>
            {
                new()
                {
                    Id = 1,
                    ServiceId = ServicesEnum.АссенизаторФиз,
                    DocumentFields = new List<DocumentField>
                    {
                        new("day", "День"),
                        new("month", "Месяц"),
                        new("year", "Год"),
                        new("fullName", "ФизическоеЛицо"),
                        new("passportSerialNumber", "ПаспортСерия"),
                        new("passportId", "ПаспортНомер"),
                        new("passportIssued", "ПаспортВыдан"),
                        new("passportIssueDate", "ПаспортДатаВыдачи"),
                        new("divisionCode", "КП"),
                        new("territoryAddress", "АдресТерритории"),
                        new("registrationAddress", "АдресРегистрации"),
                        new("price", "ЦенаЧисло"),
                        new("priceString", "ЦенаСтрока"),
                        new("phoneNumber", "НомерТелефона"),
                        new("contractValidDate", "ДоговорДействуетДо")
                    }
                },
                new()
                {
                    Id = 2,
                    ServiceId = ServicesEnum.АссенизаторЮр,
                    DocumentFields = new List<DocumentField>
                    {
                        new("day", "День"),
                        new("month", "Месяц"),
                        new("year", "Год"),
                        new("individualEntrepreneurShortName", "КороткоеИмяПредпринимателя"),
                        new("fullNameClient", "Заказчик"),
                        new("actOnTheBasis", "ДействуетНаОсновании"),
                        new("territoryAddress", "АдресТерритории"),
                        new("price", "Цена"),
                        new("priceString", "ЦенаСтрока"),
                        new("contractValidDate", "КонтрактДействуетДо"),
                        new("oGRN", "ОГРН"),
                        new("iNN", "ИНН"),
                        new("kPP", "КПП"),
                        new("legalAddress", "ЮридическийАдресс"),
                        new("phoneNumber", "телефон"),
                        new("email", "email"),
                        new("shortNameClient", "короткоеИмяЗаказчика")
                    }
                },
                new()
                {
                    Id = 3,
                    ServiceId = ServicesEnum.КГО,
                    DocumentFields = new List<DocumentField>
                    {
                        new("day", "День"),
                        new("month", "Месяц"),
                        new("year", "Год"),
                        new("fullNameClient", "Заказчик"),
                        new("actOnTheBasis", "ДействуетНаОсновании"),
                        new("volume", "Объем"),
                        new("territoryAddress", "АдресТерритории"),
                        new("machineReload", "Перегруз"),
                        new("coastPrice", "ЦенаШтрафа"),
                        new("coastPriceString", "ЦенаШтрафаСтрока"),
                        new("contractValidDate", "КонтрактДействуетДо"),
                        new("price", "Цена"),
                        new("priceString", "ЦенаСтрока"),
                        new("iNN", "ИНН"),
                        new("kPP", "КПП"),
                        new("oGRN", "ОГРН"),
                        new("oKPO", "ОКПО"),
                        new("legalAddress", "ЮридическийАдресс"),
                        new("phoneNumber", "ТелефонныйНомер"),
                        new("shortNameClient", "КороткоеИмяЗаказчика"),
                        new("clientCompany", "КомпанияЗаказчик"),
                        new("customerContactPersonAndJobTitle", "КонтактноеЛицоЗаказчика"),
                        new("phoneNumberOrFax", "КонтактныйТелефонИлиФакс"),
                        new("vehiclesNumber", "КоличествоТехники"),
                        new("startDate", "ДатаОкозанияУслугC"),
                        new("endDate", "ДатаОкозанияУслугДо"),
                        new("startTime", "ВремяОказанияУслугС"),
                        new("endTime", "ВремяОказанияУслугДо")
                    }
                }
            });
        }
    }
}