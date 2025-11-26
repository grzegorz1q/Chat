using Chat.Application.CQRS.Commands.CreateMessage;
using Chat.Application.CQRS.Queries.GetAllMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            try
            {
                var messages = await _mediator.Send(new GetAllMessagesQuery());
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok( new { id });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
