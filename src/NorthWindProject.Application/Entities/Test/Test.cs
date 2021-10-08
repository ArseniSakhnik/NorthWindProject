using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Entities.Test
{
    public class Test: IHasDomainEvent
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        [NotMapped] public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}