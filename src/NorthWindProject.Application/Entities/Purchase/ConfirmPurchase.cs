namespace NorthWindProject.Application.Entities.Purchase
{
    public class ConfirmPurchase
    {
        public int Id { get; set; }
        
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public string Guid { get; set; }
    }
}