using System.Collections.Generic;

namespace NorthWindProject.Application.Features.Purchase.Query.GetAllPurchases
{
    public class PurchaseAndPageCountDto
    {
        public IList<PurchaseDto> Purchases { get; set; }
        public int PagesCount { get; set; }
    }
}