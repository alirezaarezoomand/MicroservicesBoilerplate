using Seedworks.Core.Events;

namespace Seedworks.Core.Domain;

public class ActionHandler<TEvent> : IEventHandler<TEvent>
     where TEvent : IEvent
{
    private readonly Func<TEvent, Task> handler;

    public ActionHandler(Func<TEvent, Task> handlerDelegate)
    {
        handler = handlerDelegate;
    }

    public async Task HandleAsync(TEvent eventToHandle)
    {
        await handler(eventToHandle);
    }
}
