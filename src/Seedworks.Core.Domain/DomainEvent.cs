using Seedworks.Core.Events;

namespace Seedworks.Core.Domain;

public abstract class DomainEvent : IEvent
{
    protected DomainEvent(string aggregateId)
    {
        AggregateId = aggregateId;
        OccuredOn = DateTime.UtcNow;
    }

    public DateTime OccuredOn { get; private set; }

    public string AggregateId { get; private set; }

}
