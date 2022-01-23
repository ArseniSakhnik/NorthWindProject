using System.Collections.Generic;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class Purchase
    {
        public int Id { get; set; }
        
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public int ServiceId { get; set; }
        public Service.Service Service { get; set; }
        
        public bool IsConfirmed { get; set; }

        public List<FieldPurchase> Fields { get; set; }
    }
}