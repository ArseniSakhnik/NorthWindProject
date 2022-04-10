using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.Purchase.Query.GetVacuumTruckYurPurchase
{
    public class VacuumTruckYurPurchaseDto
    {
        public string ClientShortName { get; set; }
        public string PersonalNameEntrepreneur { get; set; }
        public string ActsOnBasis { get; set; }
        public string TerritoryAddress { get; set; }
        public string Price { get; set; }
        public string OGRN { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string LegalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ServicesEnum ServiceTypeId { get; set; }
    }
}