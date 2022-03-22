using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Entities.Services.Service>
    {
        public void Configure(EntityTypeBuilder<Entities.Services.Service> builder)
        {
            builder
                .HasMany(service => service.Purchases)
                .WithOne(purchase => purchase.Service)
                .HasForeignKey(purchase => purchase.ServiceId);
            
            builder.HasData(new List<Entities.Services.Service>
            {
                new()
                {
                    Id = ServicesEnum.АссенизаторФиз,
                },
                new()
                {
                    Id = ServicesEnum.АссенизаторЮр
                },
                new()
                {
                    Id = ServicesEnum.КГО
                }
            });
        }
    }
}