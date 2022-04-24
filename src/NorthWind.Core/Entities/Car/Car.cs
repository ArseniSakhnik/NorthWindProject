using System.Collections.Generic;

namespace NorthWind.Core.Entities.Car
{
    public class Car
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Description { get; set; }

        public List<CarInfoModel> CarModels { get; set; }
    }
}