using MediatR;

namespace Chat.Application.CQRS.Commands.CreateMessage
{
    public  record CreateMessageCommand(string Username, string Content) : IRequest<int>;
}
