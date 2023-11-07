using Seedworks.Core.Events;

namespace Seedworks.Core.Domain;

public class DomainEventsPublisher : IDomainEventPublisher
{
    private readonly IEventBus _eventBus;
    private readonly IDomainEventDetector _domainEventDetector;

    public DomainEventsPublisher(IEventBus eventBus, IDomainEventDetector domainEventDetector)
    {
        _eventBus = eventBus;
        _domainEventDetector = domainEventDetector;
    }

    public async Task PublishEventsAsync()
    {
        var events = _domainEventDetector.GetAndClearEvents();

        var tasks = events
            .Select(async (domainEvent) =>
            {
                await _eventBus.PublishAsync(domainEvent);
            });

        await Task.WhenAll(tasks);
    }
}
