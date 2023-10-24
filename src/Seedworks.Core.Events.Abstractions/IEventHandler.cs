namespace Seedworks.Core.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent eventToHandle);
    }
}