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
        protected DomainEvent()
        {
            DateOccured = DateTimeOffset.Now;
        }

        public DateTimeOffset DateOccured { get; protected set; }
        public bool IsPublished { get; set; }
    }
}