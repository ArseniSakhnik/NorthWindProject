using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Entities.Services;
using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceViewConfiguration : IEntityTypeConfiguration<ServiceView>
    {
        public void Configure(EntityTypeBuilder<ServiceView> builder)
        {
            builder.HasKey(view => view.ServiceId);

            builder.HasOne(view => view.Service)
                .WithOne(service => service.ServiceView)
                .HasForeignKey<ServiceView>(view => view.ServiceId);

            builder.HasData(new List<ServiceView>
            {
                new()
                {
                    ServiceId = ServiceEnum.Ассенизатор,
                    Title = "Откачка жидких бытовых отходов".ToUpper(),
                    MainImageName = "Assenizator.png"
                },
                new()
                {
                    ServiceId = ServiceEnum.КГО,
                    Title = "ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА".ToUpper(),
                    MainImageName = "KGO.png"
                },
                new()
                {
                    ServiceId = ServiceEnum.КДМ,
                    Title = "Полив и очистка территорий".ToUpper(),
                    MainImageName = "PolivIOchistkaTerrityriy.png"
                }
            });
        }
    }
}