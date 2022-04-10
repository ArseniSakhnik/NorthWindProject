using System;
using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.Purchase.Query.GetPurchases
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string ClientFullName { get; set; }
        public ServicesEnum ServiceTypeId { get; set; }
    }
}