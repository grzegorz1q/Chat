using Chat.Domain.Entities;
using Chat.Domain.Interfaces;
using Chat.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;            
        }
        public void Add(User user) => _context.Users.Add(user);

        public Task<User?> GetByUsernameAsync(string username) =>
            _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
