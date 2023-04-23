using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Commands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IGameRepository gameRepository)
        {
            _categoryRepository = categoryRepository;
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category categoryToRemove = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryToRemove == null)
            {
                throw new BadRequestException("This category does not exist!");
            }

            if (categoryToRemove.Games.Count > 0)
            {
                _gameRepository.RemoveGames(categoryToRemove.Games.ToList());
            }

            _categoryRepository.Delete(categoryToRemove);
            return Unit.Value;
        }
    }
}
