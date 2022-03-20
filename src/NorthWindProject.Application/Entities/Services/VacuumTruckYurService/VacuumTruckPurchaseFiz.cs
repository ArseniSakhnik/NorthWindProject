using NorthWindProject.Application.Entities.Services.BaseService;

namespace NorthWindProject.Application.Entities.Services.VacuumTruckYurService
{
    public class VacuumTruckPurchaseFiz : BasePurchase
    {
        //День
        public string Day { get; set; }

        //Месяц
        public string Month { get; set; }

        //Год
        public string Year { get; set; }

        //Физическое лицо
        public string FullName { get; set; }

        //Паспорта серия
        public string PassportSerialNumber { get; set; }

        //Паспорт номер
        public string PassportId { get; set; }

        //Паспорт выдан
        public string PassportIssued { get; set; }

        //Паспорт дата выдачи 
        public string PassportIssueDate { get; set; }
        
        //КП
        public string DivisionCode { get; set; } 

        //Адрес территории
        public string TerritoryAddress { get; set; }
        
        //Адрес регистрации
        public string RegistrationAddress { get; set; }

        //Цена
        public string Price { get; set; }

        //ЦенаСтрока
        public string PriceString { get; set; }

        //Номер телефона
        public string PhoneNumber { get; set; }
        //Контракт действует до
        public string ContractValidDate { get; set; }
    }
}