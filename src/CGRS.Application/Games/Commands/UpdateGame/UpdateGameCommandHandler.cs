using System.Threading;
using System.Threading.Tasks;

using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;

using MediatR;

namespace CGRS.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameFromDb = await _gameRepository.GetByIdAsync(request.Id);

            if (gameFromDb == null)
            {
                throw new BadRequestException("Game with given id does not exist.");
            }

            await Validate(request);

            gameFromDb.Name = request.Name;
            gameFromDb.Description = request.Description;
            gameFromDb.IsActive = request.IsActive;
            gameFromDb.IsAdultOnly = request.IsAdultOnly;
            gameFromDb.CategoryId = request.CategoryId;

            await _gameRepository.SaveChangesAsync();

            return Unit.Value;
        }

        public async Task Validate(UpdateGameCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Game name cannot be empty!");
            }

            if (string.IsNullOrEmpty(request.Description))
            {
                throw new BadRequestException("Game description cannot be empty!");
            }

            if ((await _categoryRepository.GetByIdAsync(request.CategoryId)) == null)
            {
                throw new BadRequestException("This category do not exist!");
            }

            Game gameWithGivenName = await _gameRepository.GetByNameAsync(request.Name);

            if (gameWithGivenName != null)
            {
                if (gameWithGivenName.Id != request.Id)
                {
                    throw new BadRequestException("Game with given name already exist!");
                }
            }
        }
    }
}
