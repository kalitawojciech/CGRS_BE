using System;

namespace CGRS.Application.Dtos.Categories
{
    public class CategoryInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
