using System.Threading.Tasks;
using CGRS.Application.GamesMarks.Commands.CrateGameMark;
using CGRS.Application.GamesMarks.Commands.UpdateGameMark;
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
        public async Task<IActionResult> Add([FromBody] CrateGameMarkRequest request)
        {
            await _mediator.Send(new CrateGameMarkCommand(request, User));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateGameMarkRequest request)
        {
            await _mediator.Send(new UpdateGameMarkCommand(request, User));

            return Ok();
        }
    }
}
