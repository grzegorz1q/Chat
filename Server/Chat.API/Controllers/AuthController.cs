using Chat.Application.CQRS.Commands.LoginUser;
using Chat.Application.CQRS.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator medaitor)
        {
            _mediator = medaitor;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            try
            {
                var token = await _mediator.Send(command);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(new { id });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
