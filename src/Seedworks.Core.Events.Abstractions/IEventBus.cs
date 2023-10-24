namespace Seedworks.Core.Events;

public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent eventToPublish) where TEvent : IEvent;

    void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
}