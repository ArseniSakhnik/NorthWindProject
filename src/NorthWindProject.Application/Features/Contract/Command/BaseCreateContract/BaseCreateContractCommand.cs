namespace NorthWindProject.Application.Features.Contract.Command.BaseCreateContract
{
    public abstract class BaseCreateContractCommand
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