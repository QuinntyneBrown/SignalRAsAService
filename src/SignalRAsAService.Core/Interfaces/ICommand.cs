using System.Collections.Generic;

namespace SignalRAsAService.Core.Interfaces
{
    public interface ICommand<TResponse> 
    {
        string Key { get; }        
        IEnumerable<string> SideEffects { get; }
    }
}
