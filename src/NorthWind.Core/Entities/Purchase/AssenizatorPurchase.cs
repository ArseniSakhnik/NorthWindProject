using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Purchase
{
    public class AssenizatorPurchase : Purchase
    {
        //Тип отходов
        public WasteType WasteTypeId { get; set; }

        //Объем выгребной ямы
        public int PitVolume { get; set; }

        //Расстояние от подъездного пути в метрах
        public int DistanceFromDriveway { get; set; }
    }
}