using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Games.Commands.ChangeGameActiveStatus;
using CGRS.Application.Games.Commands.CreateGame;
using CGRS.Application.Games.Commands.UpdateGame;
using CGRS.Application.Games.Queries.GetAllGames;
using CGRS.Application.Games.Queries.GetAllGamesPopulated;
using CGRS.Application.Games.Queries.GetGameById;
using CGRS.Application.Games.Queries.GetGameByIdPopulated;
using CGRS.Application.Games.Queries.Recommended;
using CGRS.Commons.Enumerables;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [Authorize]
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
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest request)
        {
            await _mediator.Send(new CreateGameCommand(request));

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Update([FromBody] UpdateGameRequest request)
        {
            await _mediator.Send(new UpdateGameCommand(request));

            return Ok();
        }

        [HttpPut("change-status/{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> ChangeActiveStatus(Guid id)
        {
            await _mediator.Send(new ChangeGameActiveStatusCommand(id));

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GameInfoResponse response = await _mediator.Send(new GetGameByIdQuery(id));

            return Ok(response);
        }

        [HttpGet("{id}/populated")]
        public async Task<IActionResult> GetByIdPopulated(Guid id)
        {
            GamePopulatedResponse response = await _mediator.Send(new GetGameByIdPopulatedQuery(id));

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GamesFilter gamesFilter)
        {
            List<GameInfoResponse> response = await _mediator.Send(new GetAllGamesQuery(gamesFilter, User));

            return Ok(response);
        }

        [HttpGet("populated")]
        public async Task<IActionResult> GetAllPopulated()
        {
            List<GamePopulatedResponse> response = await _mediator.Send(new GetAllGamesPopulatedQuery());

            return Ok(response);
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetAllRecommended()
        {
            List<GameInfoResponse> response = await _mediator.Send(new GetRecommendedGamesQuery(User));

            return Ok(response);
        }
    }
}
