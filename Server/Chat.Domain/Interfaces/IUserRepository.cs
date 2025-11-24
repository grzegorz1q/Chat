using Chat.Domain.Entities;

namespace Chat.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        void Add(User user);
    }
}
