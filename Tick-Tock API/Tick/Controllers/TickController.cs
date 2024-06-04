using Microsoft.AspNetCore.Mvc;
using SharedMessages;

namespace Tick.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TickController : ControllerBase
    {
        private readonly TickService.MessageClient _messageClient;

        public TickController(TickService.MessageClient messageClient)
        {
            _messageClient = messageClient;
        }

        [HttpPost]
        public bool Post()
        {
            _messageClient.Send(
                new TickMessage {Message = "Tick!"},
                "Tick-Message"
                );
            return true;
        }
        
    }
}
