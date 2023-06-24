using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Application.Dtos.Tags;
using CGRS.Application.Tags.Commands.CreateTag;
using CGRS.Application.Tags.Commands.EditTag;
using CGRS.Application.Tags.Commands.UpdateTag;
using CGRS.Application.Tags.Queries.GetAllTags;
using CGRS.Application.Tags.Queries.GetTagById;
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
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            await _mediator.Send(new CreateTagCommand(request));

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        [ProducesResponseType(typeof(Unit), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Edit([FromBody] UpdateTagRequest request)
        {
            await _mediator.Send(new UpdateTagCommand(request));

            return Ok();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TagInfoResponse), 200)]
        [ProducesResponseType(typeof(Unit), 404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            TagInfoResponse response = await _mediator.Send(new GetTagByIdQuery(id));

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<TagInfoResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTagsQuery());

            return Ok(result);
        }
    }
}
