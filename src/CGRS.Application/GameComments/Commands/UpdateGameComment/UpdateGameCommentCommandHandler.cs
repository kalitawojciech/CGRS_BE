using System.Threading;
using System.Threading.Tasks;
using CGRS.Application.Exceptions;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GameComments.Commands.UpdateGameComment
{
    public class UpdateGameCommentCommandHandler : IRequestHandler<UpdateGameCommentCommand>
    {
        private readonly IGameCommentRepository _gameCommentRepository;

        public UpdateGameCommentCommandHandler(IGameCommentRepository gameCommentRepository)
        {
            _gameCommentRepository = gameCommentRepository;
        }

        public async Task<Unit> Handle(UpdateGameCommentCommand request, CancellationToken cancellationToken)
        {
            var gameCommentFromDb = await _gameCommentRepository.GetByIdAsync(request.UpdateGameCommentRequest.Id);

            if (gameCommentFromDb == null)
            {
                throw new BadRequestException("Invalid game mark id");
            }

            gameCommentFromDb.Message = request.UpdateGameCommentRequest.Message;
            await _gameCommentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
