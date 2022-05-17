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
            builder.HasOne(view => view.ServiceViewSettings)
                .WithOne(settings => settings.ServiceView)
                .HasForeignKey<ServiceView>(view => view.ServiceViewSettingsId);

            builder.HasData(new List<ServiceView>
            {
                new()
                {
                    Id = ServiceViewEnum.Ассенизатор,
                    ServiceViewSettingsId = 1
                },
                new()
                {
                    Id = ServiceViewEnum.КГО,
                    ServiceViewSettingsId = 2
                },
                new()
                {
                    Id = ServiceViewEnum.КДМ,
                    ServiceViewSettingsId = 3
                }
            });
        }
    }
}