using _5by5.Learning.News.Domain.Commands.v1.User.Delete;
using _5by5.Learning.News.Domain.Commands.v1.User.Post;
using _5by5.Learning.News.Domain.Commands.v1.User.Put;
using _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _5by5.Learning.News.Api.Controllers.v1.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<GetUserCommandResponse>> Get(string id)
        {
            var response = await _mediator.Send(new GetUserCommand { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PostUserCommandResponse>> Create([FromBody]PostUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Created("",response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<PutUserCommandResponse>> Update(string id, [FromBody]PutUserCommand command)
        {
            command.Id=id;
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id:Length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return Ok();
        }
        
    }
}
