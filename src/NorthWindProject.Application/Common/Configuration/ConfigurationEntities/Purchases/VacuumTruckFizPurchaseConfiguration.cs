using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    // public class VacuumTruckFizPurchaseConfiguration : BasePurchaseConfiguration<VacuumTruckFizPurchase>
    // {
    //     private readonly IEncryptionService _encryptionService;
    //
    //     public VacuumTruckFizPurchaseConfiguration(IEncryptionService encryptionService)
    //     {
    //         _encryptionService = encryptionService;
    //     }
    //
    //     public override void Configure(EntityTypeBuilder<VacuumTruckFizPurchase> builder)
    //     {
    //         

    //         //
    //         // base.Configure(builder);
    //     }
    // }

    public class VacuumTruckFizPurchaseConfiguration : IEntityTypeConfiguration<VacuumTruckFizPurchase>
    {
        public void Configure(EntityTypeBuilder<VacuumTruckFizPurchase> builder)
        {
            // builder.Property(purchase => purchase.PassportSerialNumber)
            //     .HasEncryptDecrypt(EncryptionService.Encrypt, EncryptionService.Decipher);
            //
            // builder.Property(purchase => purchase.PassportId)
            //     .HasEncryptDecrypt(EncryptionService.Encrypt, EncryptionService.Decipher);
            //
            // builder.Property(purchase => purchase.PassportIssued)
            //     .HasEncryptDecrypt(EncryptionService.Encrypt, EncryptionService.Decipher);
            //
            // builder.Property(purchase => purchase.PassportIssueDate)
            //     .HasEncryptDecrypt(EncryptionService.Encrypt, EncryptionService.Decipher);
            //
            // builder.Property(purchase => purchase.DivisionCode)
            //     .HasEncryptDecrypt(EncryptionService.Encrypt, EncryptionService.Decipher);
        }
    }
}