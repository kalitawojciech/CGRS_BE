using System.Threading.Tasks;
using CGRS.Application.Tags.Commands.CreateTag;
using CGRS.Commons.Enumerables;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            await _mediator.Send(new CreateTagCommand(request));

            return Ok();
        }
    }
}
