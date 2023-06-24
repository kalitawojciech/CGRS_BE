using System;
using System.Collections.Generic;
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
        private readonly ITagRepository _tagRepository;
        private readonly IGamesTagRepository _gamesTagRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository, ICategoryRepository categoryRepository, ITagRepository tagRepository, IGamesTagRepository gamesTagRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _gamesTagRepository = gamesTagRepository;
        }

        public async Task<Unit> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            await Validate(request);

            var tagsFromDB = await _tagRepository.GetByIds(request.TagsIds);

            if (request.TagsIds.Count > 0)
            {
                if (tagsFromDB.Count != request.TagsIds.Count)
                {
                    throw new BadRequestException("One or more tags are invalid!");
                }
            }

            Game newGame = new Game()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                IsAdultOnly = request.IsAdultOnly,
                IsActive = true,
                CategoryId = request.CategoryId,
            };

            await _gameRepository.AddAsync(newGame);

            if (request.TagsIds.Count > 0)
            {
                await AddGameTags(request.TagsIds, newGame.Id);
            }

            return Unit.Value;
        }

        private async Task AddGameTags(List<Guid> tagsIds, Guid gameId)
        {
            List<GamesTag> gamesTags = new List<GamesTag>();

            foreach (Guid tagId in tagsIds)
            {
                gamesTags.Add(new GamesTag()
                {
                    GameId = gameId,
                    TagId = tagId,
                });
            }

            await _gamesTagRepository.AddRangeAsync(gamesTags);
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
