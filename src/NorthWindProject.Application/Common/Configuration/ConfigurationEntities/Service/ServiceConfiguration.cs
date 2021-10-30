using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Entities.Service.Service>
    {
        public void Configure(EntityTypeBuilder<Entities.Service.Service> builder)
        {
            builder
                .HasOne(service => service.ServiceView)
                .WithOne(serviceView => serviceView.Service)
                .HasForeignKey<ServiceView>(serviceView => serviceView.ServiceId);

            builder
                .HasMany(service => service.ServiceProps)
                .WithOne(serviceProp => serviceProp.Service)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}