namespace NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase
{
    public class BasePurchaseCommand
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }
    }
}