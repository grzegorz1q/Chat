using MediatR;

namespace Chat.Application.CQRS.Commands.RegisterUser
{
    public record RegisterUserCommand(string Username, string Password, string ConfirmPassword) : IRequest<int>;
}
