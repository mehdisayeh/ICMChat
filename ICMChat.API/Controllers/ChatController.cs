using ICMChat.API.Models.Chat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICMChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendQuery([FromBody] ChatRequest request)
        {
            return Ok(new ChatResponse
            {
                Message = $"You said: {request.Query}",
                Status = "Success"
            });
        }
    }
}
