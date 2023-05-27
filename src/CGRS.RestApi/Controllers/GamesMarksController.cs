using System;
using System.Threading.Tasks;
using CGRS.Application.Dtos.GamesMark;
using CGRS.Application.GamesMarks.Commands.CrateGameMark;
using CGRS.Application.GamesMarks.Commands.UpdateGameMark;
using CGRS.Application.GamesMarks.Queries.GetGameMarkForCurrentUserByGameId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GamesMarksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesMarksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Add([FromBody] CrateGameMarkRequest request)
        {
            await _mediator.Send(new CrateGameMarkCommand(request, User));

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Edit([FromBody] UpdateGameMarkRequest request)
        {
            await _mediator.Send(new UpdateGameMarkCommand(request, User));

            return Ok();
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(typeof(GameMarkResponse), 200)]
        public async Task<IActionResult> GetForCurrentUserByGameId([FromRoute] Guid gameId)
        {
            await _mediator.Send(new GetGameMarkForCurrentUserByGameIdQuery(gameId, User));

            return Ok();
        }
    }
}
