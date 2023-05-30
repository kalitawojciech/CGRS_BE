using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Games.Commands.ChangeGameActiveStatus;
using CGRS.Application.Games.Commands.CreateGame;
using CGRS.Application.Games.Commands.UpdateGame;
using CGRS.Application.Games.Queries.GetAllGames;
using CGRS.Application.Games.Queries.GetAllGamesPopulated;
using CGRS.Application.Games.Queries.GetGameById;
using CGRS.Application.Games.Queries.GetGameByIdPopulated;
using CGRS.Application.Games.Queries.GetNamesFiltered;
using CGRS.Application.Games.Queries.Recommended;
using CGRS.Commons.Enumerables;
using CGRS.Domain.Filters;
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
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest request)
        {
            await _mediator.Send(new CreateGameCommand(request));

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Update([FromBody] UpdateGameRequest request)
        {
            await _mediator.Send(new UpdateGameCommand(request));

            return Ok();
        }

        [HttpPut("change-status/{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> ChangeActiveStatus(Guid id)
        {
            await _mediator.Send(new ChangeGameActiveStatusCommand(id));

            return Ok();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GameInfoResponse), 200)]
        // [ProducesResponseType(typeof(Unit), 404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            GameInfoResponse response = await _mediator.Send(new GetGameByIdQuery(id));

            return Ok(response);
        }

        [HttpGet("{id}/populated")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GamePopulatedResponse), 200)]
        [ProducesResponseType(typeof(Unit), 404)]
        public async Task<IActionResult> GetByIdPopulated(Guid id)
        {
            GamePopulatedResponse response = await _mediator.Send(new GetGameByIdPopulatedQuery(id, User));

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResponse<GameInfoResponse>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] GamesFilter gamesFilter)
        {
            PagedResponse<GameInfoResponse> response = await _mediator.Send(new GetGamesFilteredQuery(gamesFilter, User));

            return Ok(response);
        }

        [HttpGet("get-names")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<GameNameResponse>), 200)]
        public async Task<IActionResult> GetNamesFiltered([FromQuery] string name)
        {
            List<GameNameResponse> response = await _mediator.Send(new GetNamesFilteredQuery(name));

            return Ok(response);
        }

        [HttpGet("populated")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<GamePopulatedResponse>), 200)]
        public async Task<IActionResult> GetAllPopulated()
        {
            List<GamePopulatedResponse> response = await _mediator.Send(new GetAllGamesPopulatedQuery());

            return Ok(response);
        }

        [HttpGet("recommended")]
        [ProducesResponseType(typeof(List<GameInfoResponse>), 200)]
        public async Task<IActionResult> GetAllRecommended()
        {
            List<GameInfoResponse> response = await _mediator.Send(new GetRecommendedGamesQuery(User));

            return Ok(response);
        }
    }
}
