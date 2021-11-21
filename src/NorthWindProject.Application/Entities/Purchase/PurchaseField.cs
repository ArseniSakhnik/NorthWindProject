using NorthWindProject.Application.Entities.DocumentTemplate;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class PurchaseField
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int DocumentFieldId { get; set; }
        public DocumentField DocumentField { get; set; }
        
        public string Value { get; set; }
    }
}