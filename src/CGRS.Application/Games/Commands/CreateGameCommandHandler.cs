using System;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Commands
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand>
    {
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            await _gameRepository.Add(new Game()
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
    }
}
