using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Infrastructure.SignalR
{
    public class MessageService : IMessageService
    {
        private readonly IHubContext<MessageHub> _hubContext;
        public MessageService(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageToAllAsync(Message message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", new
            {
                message.Id,
                message.User.Username,
                message.Content,
                message.Created
            });
        }
    }
}
