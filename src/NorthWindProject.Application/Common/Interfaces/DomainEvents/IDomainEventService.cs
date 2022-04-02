using System.Threading.Tasks;
using NorthWind.Core.Interfaces;

namespace NorthWindProject.Application.Common.Interfaces.DomainEvents
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}