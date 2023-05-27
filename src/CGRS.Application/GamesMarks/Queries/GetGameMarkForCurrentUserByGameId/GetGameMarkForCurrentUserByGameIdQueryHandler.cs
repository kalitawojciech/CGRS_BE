using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.GamesMark;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GamesMarks.Queries.GetGameMarkForCurrentUserByGameId
{
    public class GetGameMarkForCurrentUserByGameIdQueryHandler : IRequestHandler<GetGameMarkForCurrentUserByGameIdQuery, GameMarkResponse>
    {
        private readonly IGameMarkRepository _gameMarkRepository;
        private readonly IMapper _mapper;

        public GetGameMarkForCurrentUserByGameIdQueryHandler(IGameMarkRepository gameMarkRepository, IMapper mapper)
        {
            _gameMarkRepository = gameMarkRepository;
            _mapper = mapper;
        }

        public async Task<GameMarkResponse> Handle(GetGameMarkForCurrentUserByGameIdQuery request, CancellationToken cancellationToken)
        {
            var gameMark = _gameMarkRepository.GetByGameAndUserAsync(request.GameId, new Guid(request.User.Identity.Name));

            var result = _mapper.Map<GameMarkResponse>(gameMark);
            return result;
        }
    }
}
