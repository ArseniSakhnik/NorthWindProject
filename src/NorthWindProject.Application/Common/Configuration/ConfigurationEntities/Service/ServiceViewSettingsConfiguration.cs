using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Core.Entities.Services;
using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceViewSettingsConfiguration : IEntityTypeConfiguration<ServiceViewSettings>
    {
        public void Configure(EntityTypeBuilder<ServiceViewSettings> builder)
        {
            builder.HasData(new List<ServiceViewSettings>
            {
                new()
                {
                    Id = 1,
                    ServiceViewId = ServiceViewEnum.КГО,
                    Title = "ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА".ToUpper(),
                    MainImageName = "KGO.png"
                },
                new()
                {
                    Id = 2,
                    ServiceViewId = ServiceViewEnum.Ассенизатор,
                    Title = "Откачка жидких бытовых отходов".ToUpper(),
                    MainImageName = "Assenizator.png"
                },
                new()
                {
                    Id = 3,
                    ServiceViewId = ServiceViewEnum.КДМ,
                    Title = "Полив и очистка территорий".ToUpper(),
                    MainImageName = "PolivIOchistkaTerrityriy.png"
                }
            });
        }
    }
}