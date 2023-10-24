using Seedworks.Core.Events;

namespace Seedworks.Core.Domain;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    protected List<IEvent> _events;

    public IEnumerable<IEvent> Events => _events.AsReadOnly();

    public void RaiseEvent(IEvent @event)
    {
        _events = _events ?? new List<IEvent>();
        _events.Add(@event);
    }

    public void ClearEvents()
    {
        _events?.Clear();
    }
}
