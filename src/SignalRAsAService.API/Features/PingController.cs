using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAsAService.API.Features.Users
{
    [Authorize]
    [ApiController]
    [Route("api/ping")]
    public class PingController
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return new OkObjectResult("Pong");
        }
    }
}
