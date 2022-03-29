using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Common.Attributes;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur
{
    [Table("VacuumTruckYurPurchase")]
    public class VacuumTruckYurPurchase : BasePurchase.Purchase, IEncryptObject
    {
        [DocumentProp("КороткоеИмяПредпринимателя")]
        public string IndividualEntrepreneurShortName { get; set; }

        [DocumentProp("Заказчик")]
        public string FullNameClient { get; set; }

        [DocumentProp("ДействуетНаОсновании")]
        public string ActOnTheBasis { get; set; }
        
        [DocumentProp("АдресТерритории")]
        public string TerritoryAddress { get; set; }
        
        [DocumentProp("Цена")]
        public string Price { get; set; }
        
        [DocumentProp("ЦенаСтрока")]
        public string PriceString { get; set; }
        
        [DocumentProp("КонтрактДействуетДо")]
        public string ContractValidDate { get; set; }
        
        [DocumentProp("ОГРН")]
        public string OGRN { get; set; }
        
        [DocumentProp("ИНН")]
        public string INN { get; set; }
        
        [DocumentProp("КПП")]
        public string KPP { get; set; }
        
        [DocumentProp("ЮридическийАдресс")]
        public string LegalAddress { get; set; }
        
        [DocumentProp("Телефон")]
        public string PhoneNumber { get; set; }
        
        [DocumentProp("Email")]
        public string Email { get; set; }
        
        [DocumentProp("КороткоеИмяЗаказчика")]
        public string ShortNameClient { get; set; }
        public void DecryptObject(IEncryptionService encryptionService)
        {
            OGRN = encryptionService.Encrypt(OGRN);
            INN = encryptionService.Encrypt(INN);
            KPP = encryptionService.Encrypt(KPP);
        }

        public void EncryptObject(IEncryptionService encryptionService)
        {
            OGRN = encryptionService.Decipher(OGRN);
            INN = encryptionService.Decipher(INN);
            KPP = encryptionService.Decipher(KPP);
        }
    }
}