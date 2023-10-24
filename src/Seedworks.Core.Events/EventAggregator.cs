using System;
using System.Reflection;

namespace Seedworks.Core.Events;

public class EventAggregator : IEventBus
{
    private IList<object> _subscribers = new List<object>();

    public EventAggregator()
    {
    }

    public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
    {
        _subscribers.Add(eventHandler);
    }

    public async Task PublishAsync<TEvent>(TEvent eventToPublish)
        where TEvent : IEvent
    {
        var eligibleSubscribers = GetEligibleSubscribers(eventToPublish);

        List<Task> tasks = new List<Task>();
        eligibleSubscribers.ForEach(s =>
        {
            Type thisType = s.GetType();
            MethodInfo theMethod = thisType.GetMethod("HandleAsync");
            var task = (Task)theMethod.Invoke(s, new object[] { eventToPublish });

            tasks.Add(task);
        });

        await Task.WhenAll(tasks.ToArray());
    }

    private List<object> GetEligibleSubscribers<TEvent>(TEvent eventToPublish) where TEvent : IEvent
    {
        var handlers = _subscribers.Where(e => e.GetType().FullName.Contains(eventToPublish.GetType().FullName)).ToList();

        return handlers;
    }

}