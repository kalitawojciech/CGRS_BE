﻿using System.Threading.Tasks;
using CGRS.Application.Tags.Commands.CreateTag;
using CGRS.Application.Tags.Commands.EditTag;
using CGRS.Application.Tags.Commands.UpdateTag;
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
    }
}
