using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseFiz
{
    [Table("VacuumTruckFizPurchase")]
    public class VacuumTruckFizPurchase : Purchase, IEncryptObject
    {
        [DocumentProp("ФизическоеЛицо")] public string FullName { get; set; }

        [DocumentProp("ПаспортСерия")] public string PassportSerialNumber { get; set; }

        [DocumentProp("ПаспортНомер")] public string PassportId { get; set; }

        [DocumentProp("ПаспортВыдан")] public string PassportIssued { get; set; }

        [DocumentProp("ПаспортДатаВыдачи")] public string PassportIssueDate { get; set; }

        [DocumentProp("КП")] public string DivisionCode { get; set; }

        [DocumentProp("АдресТерритории")] public string TerritoryAddress { get; set; }

        [DocumentProp("АдресРегистрации")] public string RegistrationAddress { get; set; }

        [DocumentProp("ЦенаЧисло")] public string Price { get; set; }

        [DocumentProp("ЦенаСтрока")] public string PriceString { get; set; }

        [DocumentProp("НомерТелефона")] public string PhoneNumber { get; set; }

        [DocumentProp("ДоговорДействуетДо")] public string ContractValidDate { get; set; }

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