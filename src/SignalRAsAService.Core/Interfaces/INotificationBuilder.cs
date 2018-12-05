using System.Collections.Generic;

namespace SignalRAsAService.Core.Interfaces
{
    public interface INotificationBuilder
    {
        (List<string> emailToDistributionList, List<string> emailCcDistributionList, string subject, string body) Build(string notificationName);
    }
}
