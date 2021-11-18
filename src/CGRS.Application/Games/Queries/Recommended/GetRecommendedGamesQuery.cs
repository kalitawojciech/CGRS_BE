using System.Collections.Generic;
using System.Security.Claims;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.Recommended
{
    public class GetRecommendedGamesQuery : IRequest<List<GameInfoResponse>>
    {
        public ClaimsPrincipal User { get; set; }

        public GetRecommendedGamesQuery(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
