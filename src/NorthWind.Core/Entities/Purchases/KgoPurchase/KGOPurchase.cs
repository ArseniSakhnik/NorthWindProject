using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Purchases.BasePurchase;

namespace NorthWind.Core.Entities.Purchases.KgoPurchase
{
    [Table("KGOPurchase")]
    public class KGOPurchase : Purchase
    {
        [DocumentProp("Заказчик")] public string FullNameClient { get; set; }

        [DocumentProp("ДействуетНаОсновании")] public string ActOnTheBasis { get; set; }

        [DocumentProp("Объем")] public string Volume { get; set; }

        [DocumentProp("АдресТерритории")] public string TerritoryAddress { get; set; }

        [DocumentProp("Перегруз")] public string MachineReload { get; set; }

        [DocumentProp("ЦенаШтрафа")] public string CoastPrice { get; set; }

        [DocumentProp("ЦенаШтрафаСтрока")] public string CoastPriceString { get; set; }

        [DocumentProp("КонтрактДействуетДо")] public string ContractValidDate { get; set; }

        [DocumentProp("Цена")] public string Price { get; set; }

        [DocumentProp("ЦенаСтрока")] public string PriceString { get; set; }

        [DocumentProp("ИНН")] public string INN { get; set; }

        [DocumentProp("КПП")] public string KPP { get; set; }

        [DocumentProp("ОГРН")] public string OGRN { get; set; }

        [DocumentProp("ОКПО")] public string OKPO { get; set; }

        [DocumentProp("ЮридическийАдресс")] public string LegalAddress { get; set; }

        [DocumentProp("ТелефонныйНомер")] public string PhoneNumber { get; set; }

        [DocumentProp("КороткоеИмяЗаказчика")] public string ShortNameClient { get; set; }

        [DocumentProp("КомпанияЗаказчик")] public string ClientCompany { get; set; }

        [DocumentProp("КонтактноеЛицоЗаказчика")]
        public string CustomerContactPersonAndJobTitle { get; set; }

        [DocumentProp("КонтактныйТелефонИлиФакс")]
        public string PhoneNumberOrFax { get; set; }

        [DocumentProp("КоличествоТехники")] public string VehiclesNumber { get; set; }

        [DocumentProp("ДатаОкозанияУслугC")] public string StartDate { get; set; }

        [DocumentProp("ДатаОкозанияУслугДо")] public string EndDate { get; set; }

        [DocumentProp("ВремяОказанияУслугС")] public string StartTime { get; set; }

        [DocumentProp("ВремяОказанияУслугДо")] public string EndTime { get; set; }
    }
}