using System.Security.Claims;
using MediatR;

namespace CGRS.Application.GamesMarks.Commands.UpdateGameMark
{
    public class UpdateGameMarkCommand : IRequest
    {
        public UpdateGameMarkRequest UpdateGameMarkRequest { get; set; }

        public ClaimsPrincipal User { get; set; }

        public UpdateGameMarkCommand(UpdateGameMarkRequest updateGameMarkRequest, ClaimsPrincipal user)
        {
            UpdateGameMarkRequest = updateGameMarkRequest;
            User = user;
        }
    }
}
