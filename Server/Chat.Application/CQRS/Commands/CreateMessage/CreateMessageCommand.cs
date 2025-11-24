using MediatR;

namespace Chat.Application.CQRS.Commands.CreateMessage
{
    public  record CreateMessageCommand(int UserId, string Content) : IRequest<int>;
}
