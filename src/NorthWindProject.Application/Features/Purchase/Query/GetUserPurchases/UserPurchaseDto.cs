using NorthWind.Core.Enums;

namespace NorthWindProject.Application.Features.Purchase.Query.GetUserPurchases
{
    public class UserPurchaseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PlaceName { get; set; }
        public string Comment { get; set; }
        
        public string ServiceName { get; set; }
        
        public string Created { get; set; }

        public ServiceEnum ServiceTypeId { get; set; }
    }
}