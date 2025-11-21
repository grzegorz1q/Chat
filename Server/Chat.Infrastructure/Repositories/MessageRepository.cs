using Chat.Domain.Entities;
using Chat.Domain.Interfaces;
using Chat.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Message message)
        {
            _context.Add(message);
        }

        public Task<List<Message>> GetAllAsync()
        {
            return _context.Messages.ToListAsync();
        }

        public Task<Message?> GetByIdAsync(int id)
        {
            return _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
