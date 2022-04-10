using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.Purchase.Query.GetVacuumTruckFizPurchase
{
    public class VacuumTruckFizPurchaseDto
    {
        //Серия паспорта
        public string PassportSerialNumber { get; set; }

        //Номер паспорта
        public string PassportId { get; set; }

        //Паспорт выдан
        public string PassportIssued { get; set; }

        //Дата выдачи
        public string PassportIssueDate { get; set; }

        //Код подразделения
        public string DivisionCode { get; set; }

        //Адрес регистрации
        public string RegistrationAddress { get; set; }

        //Адрес территории
        public string TerritoryAddress { get; set; }

        //Цена
        public string Price { get; set; }
        
        public ServicesEnum ServiceTypeId { get; set; }
    }
}