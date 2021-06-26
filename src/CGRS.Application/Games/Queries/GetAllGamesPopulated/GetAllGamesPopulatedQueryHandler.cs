using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.GetAllGamesPopulated
{
    public class GetAllGamesPopulatedQueryHandler : IRequestHandler<GetAllGamesPopulatedQuery, List<GamePopulatedResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetAllGamesPopulatedQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<GamePopulatedResponse>> Handle(GetAllGamesPopulatedQuery request, CancellationToken cancellationToken)
        {
            List<Game> gamesFromDB = await _gameRepository.GetAllAsync();

            var result = _mapper.Map<List<GamePopulatedResponse>>(gamesFromDB);
            return result;
        }
    }
}
