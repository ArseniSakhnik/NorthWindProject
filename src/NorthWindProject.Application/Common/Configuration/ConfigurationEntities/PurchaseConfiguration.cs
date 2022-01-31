using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchase;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Ignore(purchase => purchase.DomainEvents);
        }
    }
}