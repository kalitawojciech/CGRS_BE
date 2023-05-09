using System;
using MediatR;

namespace CGRS.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public UpdateCategoryCommand(UpdateCategoryRequest updateCategoryRequest)
        {
            Id = updateCategoryRequest.Id;
            Name = updateCategoryRequest.Name;
            Description = updateCategoryRequest.Description;
        }
    }
}
