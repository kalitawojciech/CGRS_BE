using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ITagRepository _tagRepository;
        private readonly IGamesTagRepository _gamesTagRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository, ICategoryRepository categoryRepository, IGamesTagRepository gamesTagRepository, ITagRepository tagRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _gamesTagRepository = gamesTagRepository;
            _tagRepository = tagRepository;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var gameFromDb = await _gameRepository.GetByIdAsync(request.Id);

            if (gameFromDb == null)
            {
                throw new BadRequestException("Game with given id does not exist.");
            }

            await Validate(request);

            var tagsFromDB = await _tagRepository.GetByIds(request.TagsIds);

            if (request.TagsIds.Count > 0)
            {
                if (tagsFromDB.Count != request.TagsIds.Count)
                {
                    throw new BadRequestException("One or more tags are invalid!");
                }
            }

            gameFromDb.Name = request.Name;
            gameFromDb.Description = request.Description;
            gameFromDb.IsAdultOnly = request.IsAdultOnly;
            gameFromDb.CategoryId = request.CategoryId;

            await _gameRepository.SaveChangesAsync();

            if (request.TagsIds.Count > 0)
            {
                var currentTags = gameFromDb.GamesTags.Select(x => x.TagId).ToList();
                var tagIdsToAdd = request.TagsIds.Except(currentTags).ToList();
                await AddGameTags(tagIdsToAdd, gameFromDb.Id);

                var tagIdsToRemove = currentTags.Except(request.TagsIds).ToList();
                var gameTagsToRemove = gameFromDb.GamesTags.Where(t => tagIdsToRemove.Contains(t.TagId)).ToList();
                _gamesTagRepository.RemoveRange(gameTagsToRemove);
            }

            return Unit.Value;
        }

        private async Task Validate(UpdateGameCommand request)
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
    }
}
