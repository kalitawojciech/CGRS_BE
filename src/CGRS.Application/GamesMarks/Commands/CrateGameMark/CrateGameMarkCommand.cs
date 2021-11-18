using System.Security.Claims;
using MediatR;

namespace CGRS.Application.GamesMarks.Commands.CrateGameMark
{
    public class CrateGameMarkCommand : IRequest
    {
        public CrateGameMarkRequest CrateGameMarkRequest { get; set; }

        public ClaimsPrincipal User { get; set; }

        public CrateGameMarkCommand(CrateGameMarkRequest crateGameMarkRequest, ClaimsPrincipal user)
        {
            CrateGameMarkRequest = crateGameMarkRequest;
            User = user;
        }
    }
}
