using System.Security.Claims;
using MediatR;

namespace CGRS.Application.GameComments.Commands.UpdateGameComment
{
    public class UpdateGameCommentCommand : IRequest
    {
        public UpdateGameCommentRequest UpdateGameCommentRequest { get; set; }

        public ClaimsPrincipal User { get; set; }

        public UpdateGameCommentCommand(UpdateGameCommentRequest updateGameCommentRequest, ClaimsPrincipal user)
        {
            UpdateGameCommentRequest = updateGameCommentRequest;
            User = user;
        }
    }
}
