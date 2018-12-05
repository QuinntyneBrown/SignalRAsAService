using SignalRAsAService.Core.Models;

namespace SignalRAsAService.Core.Common
{
    public class EventStoreChanged
    {
        public EventStoreChanged(StoredEvent @event) => Event = @event;
        public StoredEvent Event { get; }
    }
}
