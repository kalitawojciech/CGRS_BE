using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.Recommended
{
    public class GetRecommendedGamesQueryHandler : IRequestHandler<GetRecommendedGamesQuery, List<GameInfoResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetRecommendedGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<GameInfoResponse>> Handle(GetRecommendedGamesQuery request, CancellationToken cancellationToken)
        {
            List<Game> gamesFromDB = await _gameRepository.GetAllAsync();
            List<Game> notPlayed = new List<Game>();

            gamesFromDB = gamesFromDB.Where(x => x.IsActive.Value).ToList();

            foreach (var game in gamesFromDB)
            {
                if (!game.GamesMarks.Where(x => x.UserId == Guid.Parse(request.User.Identity.Name)).Any())
                {
                    notPlayed.Add(game);
                }
            }

            var result = _mapper.Map<List<GameInfoResponse>>(notPlayed.OrderByDescending(x => x.AverageScore));
            return result;
        }
    }
}
