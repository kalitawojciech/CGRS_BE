using MediatR;

namespace CGRS.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest
    {
        public string Name { get; set; }

        public CreateTagCommand(CreateTagRequest createGameRequest)
        {
            Name = createGameRequest.Name;
        }
    }
}
