using System;
using System.Data;
using System.Threading.Tasks;
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
        [Authorize]
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
            var result = await _mediator.Send(new GetCategoryByIdPopulatedQuery(id));

            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UpdateCategoryRequest request)
        {
            await _mediator.Send(new UpdateCategoryCommand(request));

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        //[Authorize(Roles = UserRole.SuperAdmin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));

            return Ok();
        }
    }
}
