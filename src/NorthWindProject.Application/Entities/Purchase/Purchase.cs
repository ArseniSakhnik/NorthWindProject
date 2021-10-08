using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class Purchase : Metadata, IHasDomainEvent
    {
        public int PurchaseId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}