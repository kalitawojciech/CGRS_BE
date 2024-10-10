using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Games;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Games.Queries.Recommended
{
    public class GetRecommendedGamesQueryHandler : IRequestHandler<GetRecommendedGamesQuery, List<GameInfoResponse>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetRecommendedGamesQueryHandler(IGameRepository gameRepository, IMapper mapper, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<GameInfoResponse>> Handle(GetRecommendedGamesQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = Guid.Parse(request.User.Identity.Name);
            var allUsersList = await _userRepository.GetAllWithGamesMarksAsync();

            var currentUserGamesMarks = allUsersList.Where(u => u.Id == currentUserId)
                .SelectMany(u => u.GamesMarks).ToList();

            if (currentUserGamesMarks.Count < 1)
            {
                return await GetTopRatedNotPlayedGames(currentUserGamesMarks);
            }

            var result = await CollaborativeFiltering(currentUserId, currentUserGamesMarks, allUsersList);

            if (result.Count < 1)
            {
                return await GetTopRatedNotPlayedGames(currentUserGamesMarks);
            }

            return result;
        }

        private async Task<List<GameInfoResponse>> CollaborativeFiltering(Guid currentUserId, List<GamesMark> currentUserGamesMarks, List<User> allUsersList)
        {
            var similarUsers = GetSimilarUsers(currentUserId, currentUserGamesMarks, allUsersList);

            if (similarUsers.Count < 1)
            {
                return new List<GameInfoResponse>();
            }

            var recommendedGames = await GetRecommendedGamesBasedOnSimilarUsers(similarUsers, currentUserGamesMarks);

            if (recommendedGames.Count < 1)
            {
                return new List<GameInfoResponse>();
            }

            var result = _mapper.Map<List<GameInfoResponse>>(recommendedGames);

            return result;
        }

        private List<User> GetSimilarUsers(Guid currentUserId, List<GamesMark> currentUserGamesMarks, List<User> allUsersList)
        {
            var similarUsers = new List<User>();

            foreach (var user in allUsersList)
            {
                if (user.Id == currentUserId)
                {
                    continue;
                }

                if (user.GamesMarks.Count == 0)
                {
                    continue;
                }

                decimal cosineSimilarity = CalculateCosineSimilarity(user.GamesMarks.ToList(), currentUserGamesMarks);

                if (cosineSimilarity > 0.7m)
                {
                    similarUsers.Add(user);
                }
            }

            return similarUsers;
        }

        private decimal CalculateCosineSimilarity(List<GamesMark> gamesMarks, List<GamesMark> currentUserGamesMarks)
        {
            var commonGamesMarks = currentUserGamesMarks.Join(
                    gamesMarks,
                    currenUserMark => currenUserMark.GameId,
                    userMark => userMark.GameId,
                    (currenUserMark, userMark) => new { currenUserMark = currenUserMark.Score, userMark = userMark.Score }
                ).ToList();

            if (!commonGamesMarks.Any())
            {
                return 0;
            }

            decimal scalarProduct = (decimal)commonGamesMarks.Sum(x => x.currenUserMark * x.userMark);

            decimal currentUserVectorLength = (decimal)Math.Sqrt((double)currentUserGamesMarks.Sum(x => x.Score * x.Score));
            decimal otherUserVectorLength = (decimal)Math.Sqrt((double)gamesMarks.Sum(x => x.Score * x.Score));

            if (otherUserVectorLength == 0 || otherUserVectorLength == 0)
            {
                return 0;
            }

            var x = scalarProduct / (currentUserVectorLength * otherUserVectorLength);

            return scalarProduct / (currentUserVectorLength * otherUserVectorLength);
        }

        private async Task<List<Game>> GetRecommendedGamesBasedOnSimilarUsers(List<User> similarUsers, List<GamesMark> currentUserGamesMarks)
        {
            var similarUsersGamesIds = similarUsers.SelectMany(u => u.GamesMarks).Select(g => g.GameId).Distinct().ToList();
            var currentUserGamesIds = currentUserGamesMarks.Select(g => g.GameId).Distinct().ToList();

            var recommendedGamesIds = similarUsersGamesIds.Except(currentUserGamesIds).ToList();

            if (recommendedGamesIds.Count == 0)
            {
                return new List<Game>();
            }

            var recommendedGames = await _gameRepository.GetGamesByIdsAsync(recommendedGamesIds);

            return recommendedGames;
        }

        private async Task<List<GameInfoResponse>> GetTopRatedNotPlayedGames(List<GamesMark> currentUserGamesMarks)
        {
            var currentUserGamesIds = currentUserGamesMarks.Select(g => g.GameId).Distinct().ToList();

            var unplayedGames = await _gameRepository.GetGamesNotInIdsListAsync(currentUserGamesIds);

            var mappedUnplayedGames = _mapper.Map<List<GameInfoResponse>>(unplayedGames);

            return mappedUnplayedGames;
        }
    }
}