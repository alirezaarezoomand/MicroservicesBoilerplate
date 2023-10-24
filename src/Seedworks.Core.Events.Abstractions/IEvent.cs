namespace Seedworks.Core.Events;

public interface IEvent
{
    public DateTime OccuredOn { get; protected set; }
}