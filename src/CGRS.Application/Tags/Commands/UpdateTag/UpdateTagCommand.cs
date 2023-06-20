using System;
using CGRS.Application.Tags.Commands.UpdateTag;
using MediatR;

namespace CGRS.Application.Tags.Commands.EditTag
{
    public class UpdateTagCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UpdateTagCommand(UpdateTagRequest createGameRequest)
        {
            Name = createGameRequest.Name;
        }
    }
}
