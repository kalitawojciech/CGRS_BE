using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.GetNamesFiltered
{
    public class GetNamesFilteredQueryHandler : IRequestHandler<GetNamesFilteredQuery, List<GameNameResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetNamesFilteredQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<GameNameResponse>> Handle(GetNamesFilteredQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new List<GameNameResponse>();
            }

            var games = await _gameRepository.GetByNameFilteredAsync(request.Name);

            return _mapper.Map<List<GameNameResponse>>(games);
        }
    }
}
