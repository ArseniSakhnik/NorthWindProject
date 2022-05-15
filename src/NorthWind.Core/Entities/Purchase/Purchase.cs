using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Entities.User;

namespace NorthWind.Core.Entities.Purchase
{
    public abstract class Purchase
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }
    }
}