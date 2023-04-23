using System;
using CGRS.Application.Tags.Commands.UpdateTag;

namespace CGRS.Application.Tags.Commands.EditTag
{
    public class UpdateTagCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UpdateTagCommand(UpdateTagRequest createGameRequest)
        {
            Name = createGameRequest.Name;
            Description = createGameRequest.Description;
        }
    }
}
