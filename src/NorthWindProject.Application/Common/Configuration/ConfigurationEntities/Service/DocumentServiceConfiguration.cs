using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Entities.Contracts.BaseContract;
using NorthWind.Core.Entities.Contracts.KgoYurContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckFizContract;
using NorthWind.Core.Entities.Contracts.VacuumTruckYurContract;
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
                    Id = ServicesRequestTypeEnum.АссенизаторФиз,
                    ServiceId = ServiceEnum.Ассенизатор,
                    DocumentFields = Contract.GetDocumentFields<VacuumTruckFizContract>()
                },
                new()
                {
                    Id = ServicesRequestTypeEnum.АссенизаторЮр,
                    ServiceId = ServiceEnum.Ассенизатор,
                    DocumentFields = Contract.GetDocumentFields<VacuumTruckYurContract>()
                },
                new()
                {
                    Id = ServicesRequestTypeEnum.КГОЮр,
                    ServiceId = ServiceEnum.КГО,
                    DocumentFields = Contract.GetDocumentFields<KGOYurContract>()
                }
            });
        }
    }
}