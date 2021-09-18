using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GamesMarks.Commands.UpdateGameMark
{
    public class UpdateGameMarkCommandHandler : IRequestHandler<UpdateGameMarkCommand>
    {
        private readonly IGameMarkRepository _gameMarkRepository;
        private readonly IGameRepository _gameRepository;

        public UpdateGameMarkCommandHandler(IGameMarkRepository gameMarkRepository, IGameRepository gameRepository)
        {
            _gameMarkRepository = gameMarkRepository;
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(UpdateGameMarkCommand request, CancellationToken cancellationToken)
        {
            var gameMarkFromDb = await _gameMarkRepository.GetByIdAsync(request.UpdateGameMarkRequest.Id);

            if (gameMarkFromDb == null)
            {
                throw new BadRequestException("Invalid game mark id");
            }

            gameMarkFromDb.AverageScore = request.UpdateGameMarkRequest.AverageScore;
            await _gameMarkRepository.SaveChangesAsync();

            var gameMarksForGame = await _gameMarkRepository.GetByGameIdAsync(request.UpdateGameMarkRequest.GameId);
            var gameFromDb = await _gameRepository.GetByIdAsync(request.UpdateGameMarkRequest.GameId);

            gameFromDb.AverageScore = decimal.Round(gameMarksForGame.Sum(gm => gm.AverageScore) / gameMarksForGame.Count, 2);

            await _gameRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
