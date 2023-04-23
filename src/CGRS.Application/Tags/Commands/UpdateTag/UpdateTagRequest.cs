using System;

namespace CGRS.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
