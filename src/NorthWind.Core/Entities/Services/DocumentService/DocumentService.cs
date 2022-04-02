using System.Collections.Generic;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Entities.Services.BaseService;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Services.DocumentService
{
    public class DocumentService
    {
        public int Id { get; set; }

        public ServicesEnum ServiceId { get; set; }
        public Service Service { get; set; }

        public List<Purchase> Purchases { get; set; }
        public byte[] Content { get; set; }
        public List<DocumentField> DocumentFields { get; set; }
    }
}