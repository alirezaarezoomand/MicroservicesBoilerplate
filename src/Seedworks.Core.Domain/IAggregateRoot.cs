using Seedworks.Core.Events;

namespace Seedworks.Core.Domain
{
    public interface IAggregateRoot
    {
        IEnumerable<IEvent> Events { get; }

        void ClearEvents();
    }
}
