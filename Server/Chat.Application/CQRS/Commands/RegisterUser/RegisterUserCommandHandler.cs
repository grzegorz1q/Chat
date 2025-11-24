using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Chat.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

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
            var existing = await _userRepository.GetByUsernameAsync(request.Username);
            if (existing != null) throw new Exception("User already exists!");

            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
            var user = new User(request.Username, Convert.ToBase64String(passwordHash));

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return user.Id;
        }
    }
}
