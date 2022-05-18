using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceConfiguration : IEntityTypeConfiguration<NorthWind.Core.Entities.Services.Service>
    {
        public void Configure(EntityTypeBuilder<NorthWind.Core.Entities.Services.Service> builder)
        {
            builder
                .HasMany(service => service.Contracts)
                .WithOne(contract => contract.Service)
                .HasForeignKey(contract => contract.ServiceId);

            builder.HasData(new List<NorthWind.Core.Entities.Services.Service>
            {
                new()
                {
                    Id = ServiceEnum.Ассенизатор,
                    ServiceViewId = ServiceEnum.Ассенизатор
                },
                new()
                {
                    Id = ServiceEnum.КГО,
                    ServiceViewId = ServiceEnum.КГО
                },
                new()
                {
                    Id = ServiceEnum.КДМ,
                    ServiceViewId = ServiceEnum.КДМ,
                }
                
            });
        }
    }
}