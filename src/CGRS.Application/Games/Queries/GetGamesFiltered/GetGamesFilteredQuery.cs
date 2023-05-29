using System.Collections.Generic;
using System.Security.Claims;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Filters;
using MediatR;

namespace CGRS.Application.Games.Queries.GetAllGames
{
    public class GetGamesFilteredQuery : IRequest<List<GameInfoResponse>>
    {
        public GamesFilter GamesFilter { get; set; }

        public ClaimsPrincipal User { get; set; }

        public GetGamesFilteredQuery(GamesFilter gamesFilter, ClaimsPrincipal user)
        {
            GamesFilter = gamesFilter;
            User = user;
        }
    }
}
