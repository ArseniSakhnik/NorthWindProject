using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Test
{
    public class Test : IHasDomainEvent
    {
        public int TestId { get; set; }
        public string Name { get; set; }

        public string IgnoreValue { get; set; }
        [NotMapped] public List<DomainEvent> DomainEvents { get; set; } = new();
    }
}