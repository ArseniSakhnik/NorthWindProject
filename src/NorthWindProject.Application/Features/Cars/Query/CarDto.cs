using System.Collections.Generic;
using NorthWind.Core.Entities.Car;

namespace NorthWindProject.Application.Features.Cars.Query
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Description { get; set; }

        public List<CarInfoModel> CarModels { get; set; }
    }
}