using System.Collections.Generic;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetAllGamesPopulated
{
    public class GetAllGamesPopulatedQuery : IRequest<List<GamePopulatedResponse>>
    {
    }
}
