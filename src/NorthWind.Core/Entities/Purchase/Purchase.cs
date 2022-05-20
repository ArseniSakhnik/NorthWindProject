using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Entities.Common;
using NorthWind.Core.Entities.User;
using NorthWind.Core.Enums;

namespace NorthWind.Core.Entities.Purchase
{
    public abstract class Purchase : AuditableEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ServiceEnum ServiceTypeId { get; set; }
        public bool IsConfirmed { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Place { get; set; }
        public string Comment { get; set; }
    }
}