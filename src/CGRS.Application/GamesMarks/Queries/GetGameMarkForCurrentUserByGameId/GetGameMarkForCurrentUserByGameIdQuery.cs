using System;
using System.Security.Claims;
using CGRS.Application.Dtos.GamesMark;
using MediatR;

namespace CGRS.Application.GamesMarks.Queries.GetGameMarkForCurrentUserByGameId
{
    public class GetGameMarkForCurrentUserByGameIdQuery : IRequest<GameMarkResponse>
    {
        public Guid GameId { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetGameMarkForCurrentUserByGameIdQuery(Guid gameId, ClaimsPrincipal user)
        {
            GameId = gameId;
            User = user;
        }
    }
}
