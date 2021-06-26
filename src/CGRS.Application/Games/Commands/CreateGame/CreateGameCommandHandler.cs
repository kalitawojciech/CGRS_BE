using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand>
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            await _gameRepository.AddAsync(new Game()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                IsAdultOnly = request.IsAdultOnly,
                IsActive = true,
                CategoryId = request.CategoryId,
            });

            return Unit.Value;
        }

        public async Task Validate(CreateGameCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException("Game name cannot be empty!");
            }

            if (string.IsNullOrEmpty(request.Description))
            {
                throw new BadRequestException("Game sescription cannot be empty!");
            }

            if ((await _gameRepository.GetByNameAsync(request.Name)) != null)
            {
                throw new BadRequestException("Game with this name already used!");
            }

            if ((await _categoryRepository.GetByIdAsync(request.CategoryId)) == null)
            {
                throw new BadRequestException("This category do not exist!");
            }
        }
    }
}
