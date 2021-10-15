using System.Collections.Generic;
using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Entities.User;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class Purchase : Metadata, IHasDomainEvent
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }

        public List<PurchaseField> PurchaseFields { get; set; }
        public List<DomainEvent> DomainEvents { get; set; }
    }
}