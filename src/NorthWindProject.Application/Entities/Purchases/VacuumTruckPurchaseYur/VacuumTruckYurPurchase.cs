using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur
{
    [Table("VacuumTruckYurPurchase")]
    public class VacuumTruckYurPurchase : BasePurchase.Purchase
    {
        //День (День)
        public string Day { get; set; }

        //Месяц (Месяц)
        public string Month { get; set; }

        //Год (Год)
        public string Year { get; set; }

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
    }
}