using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchase
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Core.Entities.Purchase.Purchase>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Purchase.Purchase> builder)
        {
            
        }
    }
}