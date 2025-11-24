using Chat.Application.Dtos.Message;
using Chat.Domain.Interfaces;
using MediatR;

namespace Chat.Application.CQRS.Queries.GetAllMessages
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<ReadMessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        public GetAllMessagesQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<IEnumerable<ReadMessageDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var allMessages = await _messageRepository.GetAllAsync();

            return allMessages.Select(m => new ReadMessageDto(m.Id, m.User.Username, m.Content, m.Created));
        }
    }
}
