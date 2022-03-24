using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur
{
    [Table("VacuumTruckYurPurchase")]
    public class VacuumTruckYurPurchase : BasePurchase.Purchase, IEncryptObject
    {
        //Например ИП Морозов А.Д. (заказчик) individual entrepreneur (КороткоеИмяПредпринимателя)
        public string IndividualEntrepreneurShortName { get; set; }

        //(Заказчик)
        public string FullNameClient { get; set; }

        //(ДействуетНаОсновании)
        public string ActOnTheBasis { get; set; }
        
        //(АдресТерритории)
        public string TerritoryAddress { get; set; }
        
        //(Цена)
        public string Price { get; set; }
        
        //(ЦенаСтрока)
        public string PriceString { get; set; }
        
        //(КонтрактДействуетДо)
        public string ContractValidDate { get; set; }
        
        //(ОГРН)
        public string OGRN { get; set; }
        
        //(ИНН)
        public string INN { get; set; }
        
        //(КПП)
        public string KPP { get; set; }
        
        //(ЮридическийАдресс)
        public string LegalAddress { get; set; }
        
        //(Телефон)
        public string PhoneNumber { get; set; }
        
        //(Email)
        public string Email { get; set; }
        
        //(КороткоеИмяЗаказчика)
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