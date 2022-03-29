using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Purchases.BasePurchase;
using NorthWindProject.Application.Entities.Purchases.KgoPurchase;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;
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
                    DocumentFields = Purchase.GetDocumentFields<VacuumTruckFizPurchase>()
                },
                new()
                {
                    Id = 2,
                    ServiceId = ServicesEnum.АссенизаторЮр,
                    DocumentFields = new List<DocumentField>
                    {
                        new("individualEntrepreneurShortName", ""),
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
                    ServiceId = ServicesEnum.КГОЮр,
                    DocumentFields = Purchase.GetDocumentFields<KGOPurchase>()
                }
            });
        }
    }
}