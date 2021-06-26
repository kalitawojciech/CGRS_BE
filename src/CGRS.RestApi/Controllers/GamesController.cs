using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Games.Commands.CreateGame;
using CGRS.Application.Games.Commands.UpdateGame;
using CGRS.Application.Games.Queries.GetAllGames;
using CGRS.Application.Games.Queries.GetAllGamesPopulated;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest request)
        {
            await _mediator.Send(new CreateGameCommand(request));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameRequest request)
        {
            await _mediator.Send(new UpdateGameCommand(request));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GameInfoResponse> response = await _mediator.Send(new GetAllGamesQuery());

            return Ok(response);
        }

        [HttpGet("populated")]
        public async Task<IActionResult> GetAllPopulated()
        {
            List<GamePopulatedResponse> response = await _mediator.Send(new GetAllGamesPopulatedQuery());

            return Ok(response);
        }
    }
}
