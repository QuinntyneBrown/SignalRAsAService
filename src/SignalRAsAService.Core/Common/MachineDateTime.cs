using SignalRAsAService.Core.Interfaces;
using System;

namespace SignalRAsAService.Core.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime UtcNow { get { return System.DateTime.UtcNow; } }
    }
}
