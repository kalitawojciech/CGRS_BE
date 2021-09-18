using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameInfoResponse>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGameByIdQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameInfoResponse> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            Game gameFromDB = await _gameRepository.GetByIdAsync(request.Id);

            var result = _mapper.Map<GameInfoResponse>(gameFromDB);
            return result;
        }
    }
}
