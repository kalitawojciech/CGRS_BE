using System.Threading.Tasks;
using CGRS.Application.Games.Commands;
using CGRS.RestApi.RestModels.Games;
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
            await _mediator.Send(new CreateGameCommand(
                    request.Name,
                    request.Description,
                    request.IsAdultOnly,
                    request.CategoryId));

            return Ok();
        }
    }
}
