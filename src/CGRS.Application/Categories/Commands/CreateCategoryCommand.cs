using MediatR;

namespace CGRS.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CreateCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
