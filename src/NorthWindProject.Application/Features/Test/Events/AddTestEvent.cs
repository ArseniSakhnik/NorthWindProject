using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Test.Events
{
    public class AddTestEvent : DomainEvent
    {
        public AddTestEvent(int missionId)
        {
            MissionId = missionId;
        }

        public int MissionId { get; }
    }

    public class AddTestEventHandler : INotificationHandler<DomainEventNotification<AddTestEvent>>
    {
        public Task Handle(DomainEventNotification<AddTestEvent> notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Привет друзья это тест");
            return Task.CompletedTask;
        }
    }
}