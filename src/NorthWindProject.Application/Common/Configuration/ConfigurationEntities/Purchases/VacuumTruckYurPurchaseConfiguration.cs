using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    public class VacuumTruckYurPurchaseConfiguration : IEntityTypeConfiguration<VacuumTruckYurPurchase>
    {
        public void Configure(EntityTypeBuilder<VacuumTruckYurPurchase> builder)
        {
        }
    }
}