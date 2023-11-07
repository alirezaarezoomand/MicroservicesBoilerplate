namespace Seedworks.Core.Domain;

public interface IDomainEventPublisher
{
    public Task PublishEventsAsync();
}
