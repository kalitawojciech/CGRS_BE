using System.Collections.Generic;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetAllGames
{
    public class GetAllGamesQuery : IRequest<List<GameInfoResponse>>
    {
    }
}
