using Communications.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("add-message")]
    public async Task<IActionResult> AddMessage(AddMessageRequest addMessageRequest)
    {
        var (success, result) = await _messageService.AddMessage(addMessageRequest.Id, addMessageRequest.Sender,
            addMessageRequest.Receiver, addMessageRequest.TextTime, addMessageRequest.TextContent);
        if (!success)
        {
            return Ok("Add message failed :<");
        }
        
        return Ok("Post id: " + addMessageRequest.Id);
    }
}