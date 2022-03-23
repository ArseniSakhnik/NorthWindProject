using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Entities.Purchases.KgoPurchase
{
    [Table("KGOPurchase")]
    public class KGOPurchase : BasePurchase.Purchase
    {
        

        ////(Заказчик)
        public string FullNameClient { get; set; }

        //(ДействуетНаОсновании)
        public string ActOnTheBasis { get; set; }

        //(Объем)
        public string Volume { get; set; }

        //(АдресТерритории)
        public string TerritoryAddress { get; set; }

        //(Перегруз)
        public string MachineReload { get; set; }

        //(ЦенаШтрафа)
        public string CoastPrice { get; set; }

        //(ЦенаШтрафаСтрока)
        public string CoastPriceString { get; set; }

        //(КонтрактДействуетДо)
        public string ContractValidDate { get; set; }

        //(Цена)
        public string Price { get; set; }

        //(ЦенаСтрока)
        public string PriceString { get; set; }

        //(ИНН)
        public string INN { get; set; }

        //(КПП)
        public string KPP { get; set; }

        //(ОГРН)
        public string OGRN { get; set; }

        //(ОКПО)
        public string OKPO { get; set; }

        //(ЮридическийАдресс)
        public string LegalAddress { get; set; }

        //(ТелефонныйНомер)
        public string PhoneNumber { get; set; }

        //(КороткоеИмяЗаказчика)
        public string ShortNameClient { get; set; }

        //(КомпанияЗаказчик) 
        public string ClientCompany { get; set; }

        //(КонтактноеЛицоЗаказчика)
        public string CustomerContactPersonAndJobTitle { get; set; }

        //(КонтактныйТелефонИлиФакс)
        public string PhoneNumberOrFax { get; set; }

        //(КоличествоТехники)
        public string VehiclesNumber { get; set; }

        //(ДатаОкозанияУслугC)
        public string StartDate { get; set; }

        //(ДатаОкозанияУслугДо)
        public string EndDate { get; set; }

        //(ВремяОказанияУслугС)
        public string StartTime { get; set; }

        //(ВремяОказанияУслугДо)
        public string EndTime { get; set; }
    }
}