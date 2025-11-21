using Chat.Domain.Entities;

namespace Chat.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageToAllAsync(Message message);
    }
}
