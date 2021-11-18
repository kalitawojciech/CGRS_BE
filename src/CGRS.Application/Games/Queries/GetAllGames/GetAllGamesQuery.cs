using System.Collections.Generic;
using System.Security.Claims;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetAllGames
{
    public class GetAllGamesQuery : IRequest<List<GameInfoResponse>>
    {
        public GamesFilter GamesFilter { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetAllGamesQuery(GamesFilter gamesFilter, ClaimsPrincipal user)
        {
            GamesFilter = gamesFilter;
            User = user;
        }
    }
}
