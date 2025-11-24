using MediatR;

namespace Chat.Application.CQRS.Commands.LoginUser
{
    public record LoginUserCommand(string Username, string Password) : IRequest<string>;
}
