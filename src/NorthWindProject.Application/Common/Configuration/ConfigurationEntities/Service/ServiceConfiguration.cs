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
                .HasMany(service => service.Purchases)
                .WithOne(purchase => purchase.Service)
                .HasForeignKey(purchase => purchase.ServiceId);

            builder.HasData(new List<NorthWind.Core.Entities.Services.Service>
            {
                new()
                {
                    Id = ServicesEnum.АссенизаторФиз,
                    Route = "/create-vacuum-truck-fiz-purchase"
                },
                new()
                {
                    Id = ServicesEnum.АссенизаторЮр,
                    Route = "/create-vacuum-truck-yur-purchase"
                },
                new()
                {
                    Id = ServicesEnum.КГОЮр,
                    Route = "/create-kgo-purchase"
                }
            });
        }
    }
}