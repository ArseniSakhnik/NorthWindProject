using System.Collections.Generic;
using NorthWindProject.Application.Entities.Services.BaseService;
using NorthWindProject.Application.Entities.Services.VacuumTruckYurService;

namespace NorthWindProject.Application.Entities.Services.VacuumTruckServiceFiz
{
    public class VacuumTruckServiceFiz : BaseService.BaseService
    {
        public List<VacuumTruckPurchaseFiz> Purchases { get; set; }

    }
}