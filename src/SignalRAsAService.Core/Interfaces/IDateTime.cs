using System;

namespace SignalRAsAService.Core.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }         
    }
}
