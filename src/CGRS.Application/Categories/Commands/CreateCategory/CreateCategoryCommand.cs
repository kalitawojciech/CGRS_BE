using MediatR;

namespace CGRS.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CreateCategoryCommand(CreateCategoryRequest createCategoryRequest)
        {
            Name = createCategoryRequest.Name;
            Description = createCategoryRequest.Description;
        }
    }
}
