using System.Collections.Generic;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseFiz;

namespace NorthWindProject.Application.Entities.Services.VacuumTruckFizServiceFiz
{
    public class VacuumTruckFizService : BaseService.BaseService
    {
        public List<VacuumTruckFizPurchase> VacuumTruckFizPurchases { get; set; }
    }
}