using System.Collections.Generic;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services
{
    public class Service
    {
        public ServicesEnum Id { get; set; }

        public string Route { get; set; }

        public List<Purchase> Purchases { get; set; }
        public List<DocumentService.DocumentService> DocumentServices { get; set; }
    }
}