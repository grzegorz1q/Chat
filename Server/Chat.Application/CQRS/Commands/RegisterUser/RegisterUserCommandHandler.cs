using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Domain.Interfaces;
using MediatR;

namespace Chat.Application.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _hasher;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher hasher, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if(await _userRepository.Exists(request.Username)) 
                throw new Exception("User already exists!");

            if (request.Password != request.ConfirmPassword) //TODO: Move to FluentValidator (validator pipeline?)
                throw new Exception("'Confirm password' must match 'password'");

            var user = new User(request.Username, _hasher.Hash(request.Password));

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }
    }
}
