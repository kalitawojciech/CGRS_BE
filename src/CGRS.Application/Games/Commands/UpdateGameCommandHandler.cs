using System.Threading;
using System.Threading.Tasks;

using CGRS.Application.Exceptions;
using CGRS.Domain.Interfaces;

using MediatR;

namespace CGRS.Application.Games.Commands
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IGameRepository _gameRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameFromDb = await _gameRepository.GetByIdAsync(request.Id);

            if (gameFromDb == null)
            {
                throw new BadRequestException("Game with given id does not exist.");
            }

            gameFromDb.Name = request.Name;
            gameFromDb.Description = request.Description;
            gameFromDb.IsActive = request.IsActive;
            gameFromDb.IsAdultOnly = request.IsAdultOnly;
            gameFromDb.CategoryId = request.CategoryId;

            await _gameRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
