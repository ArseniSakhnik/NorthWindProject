using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchase
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Entities.Purchase.Purchase>
    {
        public void Configure(EntityTypeBuilder<Entities.Purchase.Purchase> builder)
        {
            builder
                .Ignore(purchase => purchase.DomainEvents);

            builder
                .HasOne(user => user.ApplicationUser)
                .WithMany(user => user.Purchases);
        }
    }
}