using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAsAService.API
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class AppHub: Hub {
        public override Task OnConnectedAsync()
        {
            var queryString = Context.GetHttpContext().Request.QueryString;

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
