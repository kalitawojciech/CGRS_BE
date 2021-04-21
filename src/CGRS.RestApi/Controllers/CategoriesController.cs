using System.Threading.Tasks;
using CGRS.Application.Categories.Commands;
using CGRS.Application.Categories.Queries;
using CGRS.Domain.Interfaces;
using CGRS.RestApi.RestModels.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CGRS.RestApi.Controllers
{
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
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            await _mediator.Send(new CreateCategoryCommand(request.Name, request.Description));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateCategoryRequest request)
        {
            await _mediator.Send(
                new UpdateCategoryCommand(
                    request.Id,
                    request.Name,
                    request.Description,
                    request.IsActive));

            return Ok();
        }
    }
}
