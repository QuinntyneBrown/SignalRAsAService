using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAsAService.Core
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AppHub: Hub {

    }
}
