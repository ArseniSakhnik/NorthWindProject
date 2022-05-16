using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Services.PurchaseService
{
    public class AssenizatorPurchaseDto : BasePurchaseDto
    {
        public WasteType WasteType { get; set; }
        public int PitVolume { get; set; }
        public int DistanceFromDriveway { get; set; }
    }
}