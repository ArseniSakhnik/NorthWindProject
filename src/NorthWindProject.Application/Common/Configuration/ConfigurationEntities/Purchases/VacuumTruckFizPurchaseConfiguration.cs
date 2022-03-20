using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Entities.Services.VacuumTruckYurService;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities.Purchases
{
    public class VacuumTruckFizPurchaseConfiguration : BasePurchaseConfiguration<VacuumTruckPurchaseFiz>
    {
        private readonly IEncryptionService _encryptionService;

        public VacuumTruckFizPurchaseConfiguration(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public override void Configure(EntityTypeBuilder<VacuumTruckPurchaseFiz> builder)
        {
            builder.Property(purchase => purchase.PassportSerialNumber)
                .HasEncryptDecrypt(_encryptionService.Encrypt, _encryptionService.Decipher);

            builder.Property(purchase => purchase.PassportId)
                .HasEncryptDecrypt(_encryptionService.Encrypt, _encryptionService.Decipher);

            builder.Property(purchase => purchase.PassportIssued)
                .HasEncryptDecrypt(_encryptionService.Encrypt, _encryptionService.Decipher);

            builder.Property(purchase => purchase.PassportIssueDate)
                .HasEncryptDecrypt(_encryptionService.Encrypt, _encryptionService.Decipher);

            builder.Property(purchase => purchase.DivisionCode)
                .HasEncryptDecrypt(_encryptionService.Encrypt, _encryptionService.Decipher);

            base.Configure(builder);
        }
    }
}