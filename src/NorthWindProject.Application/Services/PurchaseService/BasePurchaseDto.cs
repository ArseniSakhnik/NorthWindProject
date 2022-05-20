using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Services.PurchaseService
{
    public class BasePurchaseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }
        
        public bool IsConfirmed { get; set; }
        
        public ServiceEnum ServiceTypeId { get; set; }
    }
}