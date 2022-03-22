using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchases.BasePurchase;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    public abstract class PurchaseConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : Purchase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Ignore(purchase => purchase.GetNameAndValuesDictionary);
        }
    }
}