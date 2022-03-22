using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Interfaces;

namespace NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz
{
    [Table("VacuumTruckFizPurchase")]
    public class VacuumTruckFizPurchase : BasePurchase.Purchase, IEncryptObject
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