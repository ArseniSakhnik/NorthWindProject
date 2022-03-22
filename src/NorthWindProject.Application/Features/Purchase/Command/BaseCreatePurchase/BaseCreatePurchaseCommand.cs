namespace NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase
{
    public abstract class BaseCreatePurchaseCommand
    {
        //Email
        public string Email { get; set; }
        //Номер телефона
        public string PhoneNumber { get; set; }
        //Имя
        public string Name { get; set; }
        //Фамилия
        public string Surname { get; set; }
        //Отчество
        public string MiddleName { get; set; }

    }
}