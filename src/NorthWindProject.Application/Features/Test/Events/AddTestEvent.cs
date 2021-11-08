﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Interfaces.DomainEvents;

namespace NorthWindProject.Application.Features.Test.Events
{
    public class AddTestEvent : DomainEvent
    {
        public int MissionId { get; }

        public AddTestEvent(int missionId)
        {
            MissionId = missionId;
        }
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