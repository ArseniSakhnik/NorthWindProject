using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchase;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchase
{
    public class PurchaseFieldConfiguration : IEntityTypeConfiguration<PurchaseField>
    {
        public void Configure(EntityTypeBuilder<PurchaseField> builder)
        {
            
        }
    }
}