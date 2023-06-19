using Communications.Requests;
using Microsoft.AspNetCore.Mvc;
using Models;
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

    [HttpPut("change-message-content")]
    public async Task<IActionResult> UpdateMessageContent(UpdateMessageRequest updateMessageRequest)
    {
        var (success, result) =
            await _messageService.UpdateMessageContent(updateMessageRequest.Id, updateMessageRequest.TextContent);
        if (!success)
        {
            return Ok("Message change failed");
        }
        
        return Ok("Message content updated!");
    }

    [HttpGet("get-message-in-24-hour")]
    public List<Message> GetMessageIn24Hour()
    {
        var result = _messageService.GetMessageIn24Hour();
        return result;
    }
}