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
        private readonly IMapper _mapper;

        public GetGameByIdPopulatedQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GamePopulatedResponse> Handle(GetGameByIdPopulatedQuery request, CancellationToken cancellationToken)
        {
            Game gameFromDB = await _gameRepository.GetByIdPopulatedAsync(request.Id);

            if (gameFromDB == null)
            {
                throw new NotFoundException();
            }

            var result = _mapper.Map<GamePopulatedResponse>(gameFromDB);
            return result;
        }
    }
}
