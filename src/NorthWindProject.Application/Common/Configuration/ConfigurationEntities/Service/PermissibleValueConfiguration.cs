using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Service;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Service
{
    public class PermissibleValueConfiguration : IEntityTypeConfiguration<ServiceProp>
    {
        public void Configure(EntityTypeBuilder<ServiceProp> builder)
        {
            builder
                .HasMany(serviceProp => serviceProp.PermissibleValues)
                .WithOne(permissibleValue => permissibleValue.ServiceProp)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}