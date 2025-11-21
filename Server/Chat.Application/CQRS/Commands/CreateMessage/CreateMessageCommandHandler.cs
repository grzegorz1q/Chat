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
        private readonly IMessageService _messageService;
        
        public CreateMessageCommandHandler(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IMessageService messageService)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _messageService = messageService;
        }
        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message(request.Username, request.Content);
            _messageRepository.Add(message);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _messageService.SendMessageToAllAsync(message);
            return message.Id;
        }
    }
}
