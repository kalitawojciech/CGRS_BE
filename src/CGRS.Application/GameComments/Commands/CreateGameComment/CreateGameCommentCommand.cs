using System.Security.Claims;
using MediatR;

namespace CGRS.Application.GameComments.Commands.CreateGameComment
{
    public class CreateGameCommentCommand : IRequest
    {
        public CreateGameCommentRequest CreateGameCommentRequest { get; set; }

        public ClaimsPrincipal User { get; set; }

        public CreateGameCommentCommand(CreateGameCommentRequest createGameCommentRequest, ClaimsPrincipal user)
        {
            CreateGameCommentRequest = createGameCommentRequest;
            User = user;
        }
    }
}
