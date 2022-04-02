using System;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Common.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IPublisher _mediator;

        public DomainEventService(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification) Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}