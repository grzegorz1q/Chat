using Chat.Application.Dtos.Message;
using MediatR;

namespace Chat.Application.CQRS.Queries.GetAllMessages
{
    public record GetAllMessagesQuery() : IRequest<IEnumerable<ReadMessageDto>>;
}
