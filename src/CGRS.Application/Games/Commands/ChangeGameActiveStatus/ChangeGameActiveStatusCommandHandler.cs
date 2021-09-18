using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Commands.ChangeGameActiveStatus
{
    public class ChangeGameActiveStatusCommandHandler : IRequestHandler<ChangeGameActiveStatusCommand>
    {
        private readonly IGameRepository _gameRepository;

        public ChangeGameActiveStatusCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(ChangeGameActiveStatusCommand request, CancellationToken cancellationToken)
        {
            Game gameFromDb = await _gameRepository.GetByIdAsync(request.Id);

            if (gameFromDb == null)
            {
                throw new BadRequestException("Given game does not exist");
            }

            gameFromDb.IsActive = !gameFromDb.IsActive;
            await _gameRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
