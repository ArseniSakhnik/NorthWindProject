using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Entities.Contracts.KgoYurContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckFizContract;
using NorthWind.Core.Entities.Services.BaseService;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Common.Extensions;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class
        DocumentServiceConfiguration : IEntityTypeConfiguration<
            NorthWind.Core.Entities.Services.DocumentService.DocumentService>
    {
        public void Configure(
            EntityTypeBuilder<NorthWind.Core.Entities.Services.DocumentService.DocumentService> builder)
        {
            builder
                .HasMany(service => service.Contracts)
                .WithOne(contract => contract.DocumentService)
                .HasForeignKey(contract => contract.DocumentServiceId);

            builder
                .Property(e => e.DocumentFields)
                .HasJsonConversion();

            builder.HasData(new List<NorthWind.Core.Entities.Services.DocumentService.DocumentService>
            {
                new()
                {
                    Id = 1,
                    ServiceId = ServicesEnum.АссенизаторФиз,
                    DocumentFields = Contract.GetDocumentFields<VacuumTruckFizContract>()
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
                    DocumentFields = Contract.GetDocumentFields<KGOYurContract>()
                }
            });
        }
    }
}