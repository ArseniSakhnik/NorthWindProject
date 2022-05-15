namespace NorthWind.Core.Entities.Purchase
{
    public class KGOPurchase : Purchase
    {
        //какой объем мусора планируется вывозить 
        public int PlannedWasteVolume { get; set; }

        // Расстояние от подъездного пути в метрах
        public int DistanceFromDriveway { get; set; }
    }
}