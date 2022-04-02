using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseFiz
{
    [Table("VacuumTruckFizPurchase")]
    public class VacuumTruckFizPurchase : Purchase, IEncryptObject
    {
        [DocumentProp("физическоелицополностью")] public string FullName { get; set; }

        [DocumentProp("паспортсерия")] public string PassportSerialNumber { get; set; }

        [DocumentProp("паспортномер")] public string PassportId { get; set; }

        [DocumentProp("паспортвыдан")] public string PassportIssued { get; set; }

        [DocumentProp("паспортдатавыдачи")] public string PassportIssueDate { get; set; }

        [DocumentProp("кп")] public string DivisionCode { get; set; }

        [DocumentProp("адрестерритории")] public string TerritoryAddress { get; set; }

        [DocumentProp("адресрегистрации")] public string RegistrationAddress { get; set; }

        [DocumentProp("ценачисло")] public string Price { get; set; }

        [DocumentProp("ценастрока")] public string PriceString { get; set; }

        [DocumentProp("номертелефона")] public string PhoneNumber { get; set; }
        
        public void DecryptObject(IEncryptionService encryptionService)
        {
            PassportSerialNumber = encryptionService.Decipher(PassportSerialNumber);
            PassportId = encryptionService.Decipher(PassportId);
            PassportIssued = encryptionService.Decipher(PassportIssued);
            PassportIssueDate = encryptionService.Decipher(PassportIssueDate);
            DivisionCode = encryptionService.Decipher(DivisionCode);
        }

        public void EncryptObject(IEncryptionService encryptionService)
        {
            PassportSerialNumber = encryptionService.Encrypt(PassportSerialNumber);
            PassportId = encryptionService.Encrypt(PassportId);
            PassportIssued = encryptionService.Encrypt(PassportIssued);
            PassportIssueDate = encryptionService.Encrypt(PassportIssueDate);
            DivisionCode = encryptionService.Encrypt(DivisionCode);
        }
    }
}