namespace Seedworks.Core.Events;

public class EventAlreadyAddedException : Exception
{
    public EventAlreadyAddedException()
    {
    }

    public EventAlreadyAddedException(string handlerName) :
        base($"EventHandler [{handlerName}] already added.")
    {

    }
}