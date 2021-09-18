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

namespace CGRS.Application.Games.Queries.GetAllGames
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GameInfoResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetAllGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<GameInfoResponse>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            List<Game> gamesFromDB = await _gameRepository.GetAllAsync();

            if (request.GamesFilter.IsActive.Value == true)
            {
                gamesFromDB = gamesFromDB.Where(x => x.IsActive.Value).ToList();

                foreach (var game in gamesFromDB)
                {
                    game.GamesMarks = game.GamesMarks.Where(x => x.UserId == Guid.Parse(request.User.Identity.Name)).ToList();
                }
            }

            if (request.GamesFilter.IsActive == false)
            {
                foreach (var game in gamesFromDB)
                {
                    game.GamesMarks.Clear();
                }
            }

            var result = _mapper.Map<List<GameInfoResponse>>(gamesFromDB);
            return result;
        }
    }
}
