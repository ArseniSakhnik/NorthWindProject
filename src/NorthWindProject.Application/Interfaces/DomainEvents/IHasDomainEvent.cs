using System;
using System.Collections.Generic;

namespace NorthWindProject.Application.Interfaces.DomainEvents
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