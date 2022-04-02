using System;
using System.Collections.Generic;

namespace NorthWind.Core.Interfaces
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }

    public abstract class DomainEvent
    {
        public DateTimeOffset DateOccured { get; protected set; }
        public bool IsPublished { get; set; }
        
        protected DomainEvent()
        {
            DateOccured = DateTimeOffset.Now;
        }
    }
}