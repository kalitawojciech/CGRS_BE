using System.Threading.Tasks;
using CGRS.Application.Games.Commands.CreateGame;
using CGRS.Application.Games.Commands.UpdateGame;
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
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
