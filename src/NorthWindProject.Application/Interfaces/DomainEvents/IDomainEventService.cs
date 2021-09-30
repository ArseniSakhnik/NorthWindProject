using System.Threading.Tasks;

namespace NorthWindProject.Application.Interfaces.DomainEvents
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}