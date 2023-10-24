namespace Seedworks.Core.Events
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent eventToPublish)
            where TEvent : IEvent;

        Task PublishAsync<TEvent>(Action<TEvent> action) where TEvent : IEvent;
    }
}