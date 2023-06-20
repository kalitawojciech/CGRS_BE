using System;

namespace CGRS.Application.Dtos.Tags
{
    public class TagInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
}
