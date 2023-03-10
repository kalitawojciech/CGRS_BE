using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GamesMarks.Commands.CrateGameMark
{
    public class CrateGameMarkCommandHandler : IRequestHandler<CrateGameMarkCommand>
    {
        private readonly IGameMarkRepository _gameMarkRepository;
        private readonly IGameRepository _gameRepository;

        public CrateGameMarkCommandHandler(IGameMarkRepository gameMarkRepository, IGameRepository gameRepository)
        {
            _gameMarkRepository = gameMarkRepository;
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(CrateGameMarkCommand request, CancellationToken cancellationToken)
        {
            GamesMark gameMarkToAdd = new GamesMark()
            {
                Id = Guid.NewGuid(),
                GameId = request.CrateGameMarkRequest.GameId,
                UserId = Guid.Parse(request.User.Identity.Name),
                Score = request.CrateGameMarkRequest.AverageScore,
            };

            await _gameMarkRepository.AddAsync(gameMarkToAdd);

            var gameMarksForGame = await _gameMarkRepository.GetByGameIdAsync(request.CrateGameMarkRequest.GameId);
            var gameFromDb = await _gameRepository.GetByIdAsync(request.CrateGameMarkRequest.GameId);

            gameFromDb.AverageScore = decimal.Round(gameMarksForGame.Sum(gm => gm.Score).Value / gameMarksForGame.Count, 2);

            await _gameRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
