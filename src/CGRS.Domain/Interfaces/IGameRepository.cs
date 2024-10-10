using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Filters;

namespace CGRS.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task AddAsync(Game game);

        Task<Game> GetByIdAsync(Guid id);

        Task SaveChangesAsync();

        Task<List<Game>> GetAllAsync();

        Task<Game> GetByNameAsync(string name);

        void RemoveGame(Game gameToRemove);

        void RemoveGames(List<Game> gamesToRemove);

        Task<Game> GetByIdPopulatedAsync(Guid id);

        Task<List<Game>> GetByNameFilteredAsync(string name);

        Task<PagedEntity<Game>> GetFilteredAsync(GamesFilter filter, ClaimsPrincipal user);

        Task<List<Game>> GetGamesByIdsAsync(List<Guid> ids);

        Task<List<Game>> GetGamesNotInIdsListAsync(List<Guid> ids);
    }
}
