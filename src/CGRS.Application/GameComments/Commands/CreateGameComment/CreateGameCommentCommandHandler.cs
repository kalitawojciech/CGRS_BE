using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.GameComments.Commands.CreateGameComment
{
    public class CreateGameCommentCommandHandler : IRequestHandler<CreateGameCommentCommand>
    {
        private readonly IGameCommentRepository _gameCommentRepository;

        public CreateGameCommentCommandHandler(IGameCommentRepository gameCommentRepository)
        {
            _gameCommentRepository = gameCommentRepository;
        }

        public async Task<Unit> Handle(CreateGameCommentCommand request, CancellationToken cancellationToken)
        {
            GameComment gameCommentToAdd = new GameComment()
            {
                Id = Guid.NewGuid(),
                GameId = request.CreateGameCommentRequest.GameId,
                UserId = Guid.Parse(request.User.Identity.Name),
                Message = request.CreateGameCommentRequest.Message,
            };

            await _gameCommentRepository.AddAsync(gameCommentToAdd);

            return Unit.Value;
        }
    }
}
