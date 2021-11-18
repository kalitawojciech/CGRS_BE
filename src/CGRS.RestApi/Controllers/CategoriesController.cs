using System;
using System.Threading.Tasks;
using CGRS.Application.Categories.Commands.ChangeActivityStatus;
using CGRS.Application.Categories.Commands.CreateCategory;
using CGRS.Application.Categories.Commands.RemoveCategory;
using CGRS.Application.Categories.Commands.UpdateCategory;
using CGRS.Application.Categories.Queries;
using CGRS.Commons.Enumerables;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            await _mediator.Send(new CreateCategoryCommand(request));

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));

            return Ok(result);
        }

        [HttpGet("{id}/populated")]
        [Authorize]
        public async Task<IActionResult> GetByIdPopulated(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdPopulatedQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Edit([FromBody] UpdateCategoryRequest request)
        {
            await _mediator.Send(new UpdateCategoryCommand(request));

            return Ok();
        }

        [HttpPut("change-status/{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> ChangeActiveStatus(Guid id)
        {
            await _mediator.Send(new ChangeCategoryActiveStatusCommand(id));

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.SuperAdmin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));

            return Ok();
        }
    }
}
