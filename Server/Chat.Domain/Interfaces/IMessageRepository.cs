using Chat.Domain.Entities;

namespace Chat.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(int id);
        Task<List<Message>> GetAllAsync();
        void Add(Message message);
    }
}
