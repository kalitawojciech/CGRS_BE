using System.Collections.Generic;
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

            var result = _mapper.Map<List<GameInfoResponse>>(gamesFromDB);
            return result;
        }
    }
}
