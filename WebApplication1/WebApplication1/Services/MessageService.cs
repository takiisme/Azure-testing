using System.Runtime.InteropServices.JavaScript;
using Models;

namespace WebApplication1.Services;

public interface IMessageService
{
    public Task<(bool success, object result)> AddMessage(int id, int senderId, int receiverId, DateTime textTime,
        string textContent);

    public Task<(bool success, object result)> UpdateMessageContent(int id, string textContent);

    public List<Message> GetMessageIn24Hour();
}

public class MessageService : IMessageService
{
    private readonly DbContext _dbContext;
    private readonly HelperService _helperService;

    public MessageService(DbContext dbContext, HelperService helperService)
    {
        _dbContext = dbContext;
        _helperService = helperService;
    }

    public async Task<(bool success, object result)> AddMessage(int id, int senderId, int receiverId, DateTime textTime,
        string textContent)
    {
        if (!_helperService.DoesEmployeeIdExist(senderId) || !_helperService.DoesEmployeeIdExist(receiverId))
        {
            return (false, "Sender/Receiver does not exist");
        }

        var sender = _dbContext.Employees.First((x) => x.Id == senderId);
        var receiver = _dbContext.Employees.First((x) => x.Id == receiverId);

        var messageInformation = new Message()
        {
            Id = id,
            Sender = sender,
            Receiver = receiver,
            TextTime = textTime,
            TextContent = textContent,
        };

        _dbContext.Messages.Add(messageInformation);
        _dbContext.SaveChanges();
        return (true, "Success");
    }

    public async Task<(bool success, object result)> UpdateMessageContent(int id, string textContent)
    {
        if (!_helperService.DoesMessageIdExist(id))
        {
            return (false, "Message does not exist");
        }

        var message = _dbContext.Messages.First((x) => x.Id == id);
        message.TextContent = textContent;

        _dbContext.SaveChanges();
        return (true, "Success");
    }

    public List<Message> GetMessageIn24Hour()
    {
        var message =
            _dbContext.Messages.Where(text => text.TextTime >= DateTime.Today.AddDays(-1) && text.TextTime <= DateTime.Now).ToList();
        
        return message;
    }
}