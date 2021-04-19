using System;
using MediatR;

namespace CGRS.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public UpdateCategoryCommand(Guid id, string name, string description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
