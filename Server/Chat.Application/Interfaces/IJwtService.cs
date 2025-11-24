using Chat.Domain.Entities;

namespace Chat.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
