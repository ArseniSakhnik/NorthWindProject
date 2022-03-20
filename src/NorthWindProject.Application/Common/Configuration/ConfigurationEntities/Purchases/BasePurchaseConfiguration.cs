using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    public abstract class BasePurchaseConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BasePurchase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Ignore(purchase => purchase.GetNameAndValuesDictionary);
        }
    }
}