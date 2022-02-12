using MediatR;

namespace NorthWindProject.Application.Features.Purchase.Command.BaseCreatePurchase
{
    public abstract class BaseCreatePurchaseCommand
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
    }
}