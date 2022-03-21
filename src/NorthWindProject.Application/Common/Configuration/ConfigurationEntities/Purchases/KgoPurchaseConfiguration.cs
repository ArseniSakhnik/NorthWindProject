using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchases.KgoPurchase;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    public class KgoPurchaseConfiguration : IEntityTypeConfiguration<KGOPurchase>
    {
        public void Configure(EntityTypeBuilder<KGOPurchase> builder)
        {
        }
    }
}