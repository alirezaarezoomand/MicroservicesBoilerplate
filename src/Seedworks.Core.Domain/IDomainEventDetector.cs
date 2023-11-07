namespace Seedworks.Core.Domain;

public interface IDomainEventDetector
{
    public IEnumerable<DomainEvent> GetAndClearEvents();
}
