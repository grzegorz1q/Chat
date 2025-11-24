using Chat.Application.Interfaces;
using Chat.Domain.Interfaces;
using MediatR;

namespace Chat.Application.CQRS.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtService _jwtService;
        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher hasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null || !_hasher.Verify(request.Password, user.PasswordHash))
                throw new Exception("Incorrect login or password"); //TODO: Add custom exception

            var token = _jwtService.GenerateToken(user);
            return token;
        }
    }
}
