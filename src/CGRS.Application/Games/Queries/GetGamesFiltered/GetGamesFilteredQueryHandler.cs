﻿using System;
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
    public class GetGamesFilteredQueryHandler : IRequestHandler<GetGamesFilteredQuery, List<GameInfoResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GetGamesFilteredQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<GameInfoResponse>> Handle(GetGamesFilteredQuery request, CancellationToken cancellationToken)
        {
            List<Game> gamesFromDB = await _gameRepository.GetFilteredAsync(request.GamesFilter, request.User);

            var result = _mapper.Map<List<GameInfoResponse>>(gamesFromDB);
            return result;
        }
    }
}
