using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class FieldPurchase
    {
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        
        public int FieldServiceId { get; set; }
        public FieldService FieldService { get; set; }
    }
}