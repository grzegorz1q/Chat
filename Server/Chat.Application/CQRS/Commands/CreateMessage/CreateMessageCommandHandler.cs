using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Domain.Interfaces;
using MediatR;

namespace Chat.Application.CQRS.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateMessageCommandHandler(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message(request.Username, request.Content);
            _messageRepository.Add(message);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return message.Id;
        }
    }
}
