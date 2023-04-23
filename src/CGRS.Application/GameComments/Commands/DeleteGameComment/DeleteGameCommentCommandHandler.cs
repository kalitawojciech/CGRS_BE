using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GameComments.Commands.DeleteGameComment
{
    public class DeleteGameCommentCommandHandler : IRequestHandler<DeleteGameCommentCommand>
    {
        private readonly IGameCommentRepository _gameCommentRepository;

        public DeleteGameCommentCommandHandler(IGameCommentRepository gameCommentRepository)
        {
            _gameCommentRepository = gameCommentRepository;
        }

        public async Task<Unit> Handle(DeleteGameCommentCommand request, CancellationToken cancellationToken)
        {
            var gameCommentFromDb = await _gameCommentRepository.GetByIdAsync(request.Id);

            if (gameCommentFromDb == null)
            {
                throw new BadRequestException("Game comment does not exist");
            }

            _gameCommentRepository.Delete(gameCommentFromDb);

            return Unit.Value;
        }
    }
}
