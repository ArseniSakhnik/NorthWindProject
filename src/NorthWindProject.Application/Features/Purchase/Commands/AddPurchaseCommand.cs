using MediatR;

namespace NorthWindProject.Application.Features.Purchase.Commands
{
    public class AddPurchaseCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ServiceId { get; set; }
        
    }
}