using System;

namespace CGRS.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
