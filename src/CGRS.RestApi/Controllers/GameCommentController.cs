using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGRS.Application.GameComments.Commands.CreateGameComment;
using CGRS.Application.GameComments.Commands.DeleteGameComment;
using CGRS.Application.GameComments.Commands.UpdateGameComment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GameCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameCommentRequest request)
        {
            await _mediator.Send(new CreateGameCommentCommand(request, User));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateGameCommentRequest request)
        {
            await _mediator.Send(new UpdateGameCommentCommand(request, User));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteGameCommentCommand(id));

            return Ok();
        }
    }
}
