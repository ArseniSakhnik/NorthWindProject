namespace NorthWindProject.Application.Services.PurchaseService
{
    public class KGOPurchaseDto : BasePurchaseDto
    {
        public int PlannedWasteVolume { get; set; }
        public int DistanceFromDriveway { get; set; }
    }
}