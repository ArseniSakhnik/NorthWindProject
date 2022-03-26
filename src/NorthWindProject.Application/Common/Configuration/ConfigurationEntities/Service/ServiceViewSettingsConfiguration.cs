using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Services;
using NorthWindProject.Application.Enums;

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
                    ServiceViewId = ServiceViewEnum.Ассенизатор,
                    Title = "ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА".ToUpper(),
                    MainImageName = "KGO.png"
                },
                new()
                {
                    Id = 2,
                    ServiceViewId = ServiceViewEnum.КГО,
                    Title = "Откачка жидких бытовых отходов".ToUpper(),
                    MainImageName = "Assenizator.png"
                }
            });
        }
    }
}