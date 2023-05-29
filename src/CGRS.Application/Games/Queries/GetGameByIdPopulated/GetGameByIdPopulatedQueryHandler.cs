using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.GetGameByIdPopulated
{
    public class GetGameByIdPopulatedQueryHandler : IRequestHandler<GetGameByIdPopulatedQuery, GamePopulatedResponse>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameMarkRepository _gameMarkRepository;
        private readonly IMapper _mapper;

        public GetGameByIdPopulatedQueryHandler(IGameRepository gameRepository, IMapper mapper, IGameMarkRepository gameMarkRepository = null)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _gameMarkRepository = gameMarkRepository;
        }

        public async Task<GamePopulatedResponse> Handle(GetGameByIdPopulatedQuery request, CancellationToken cancellationToken)
        {
            Game gameFromDB = await _gameRepository.GetByIdPopulatedAsync(request.Id);

            if (gameFromDB == null)
            {
                throw new NotFoundException();
            }

            if (request.User.Identity.IsAuthenticated)
            {
                var userId = new Guid(request.User.Identity.Name);
                GamesMark userGameMark = await _gameMarkRepository.GetByGameAndUserAsync(request.Id, userId);

                gameFromDB.GamesMarks.Add(userGameMark);
            }

            var result = _mapper.Map<GamePopulatedResponse>(gameFromDB);
            return result;
        }
    }
}
