using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

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
    }
}
