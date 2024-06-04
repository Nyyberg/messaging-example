using Microsoft.AspNetCore.Mvc;
using SharedMessages;
using TickService;

namespace TockService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TockController : ControllerBase
    {
        private readonly MessageClient _messageClient;

        public TockController(MessageClient messageClient)
        {
            _messageClient = messageClient;
        }

        [HttpPost]
        public bool Post()
        {
            _messageClient.Send<TockMessage>(new TockMessage { Message = "Tock!" }, "tock-message");
            return true;
        }
    }
}
