using System.Collections.Generic;
using NorthWindProject.Application.Entities.Purchases.KgoPurchase;

namespace NorthWindProject.Application.Entities.Services.KGOService
{
    public class KGOService : BaseService.BaseService
    {
        public List<KGOPurchase> KgoPurchases { get; set; }
    }
}