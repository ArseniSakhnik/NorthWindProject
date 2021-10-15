using NorthWindProject.Application.Entities.Service;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class PurchaseField
    {
        public int PurchaseFieldId { get; set; }
        public int ServicePropId { get; set; }
        public ServiceProp ServiceProp { get; set; }
        public string Value { get; set; }
    }
}