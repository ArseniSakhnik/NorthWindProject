using System.Collections.Generic;
using NorthWindProject.Application.Entities.Purchases.VacuumTruckPurchaseYur;

namespace NorthWindProject.Application.Entities.Services.VacuumTruckServiceYur
{
    public class VacuumTruckYurService : BaseService.BaseService
    {
        public List<VacuumTruckYurPurchase> VacuumTruckYurPurchases { get; set; }
    }
}