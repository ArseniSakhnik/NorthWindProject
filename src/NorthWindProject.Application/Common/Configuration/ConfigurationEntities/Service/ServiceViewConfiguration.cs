﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Services;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceViewConfiguration : IEntityTypeConfiguration<ServiceView>
    {
        public void Configure(EntityTypeBuilder<ServiceView> builder)
        {
            builder.HasOne(view => view.ServiceViewSettings)
                .WithOne(settings => settings.ServiceView)
                .HasForeignKey<Entities.Services.ServiceView>(view => view.ServiceViewSettingsId);
            
            builder.HasData(new List<ServiceView>
            {
                new()
                {
                    Id = ServiceViewEnum.Ассенизатор,
                    FizServiceId = ServicesEnum.АссенизаторФиз,
                    YurServiceId = ServicesEnum.АссенизаторЮр,
                    ServiceViewSettingsId = 1
                },
                new()
                {
                    Id = ServiceViewEnum.КГО,
                    YurServiceId = ServicesEnum.КГОЮр,
                    ServiceViewSettingsId = 2
                }
            });
        }
    }
}