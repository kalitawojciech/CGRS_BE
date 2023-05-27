using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGameMarkRepository
    {
        public Task AddAsync(GamesMark gameMark);

        public Task SaveChangesAsync();

        public Task<GamesMark> GetByIdAsync(Guid id);

        public Task<GamesMark> GetByGameAndUserAsync(Guid gameId, Guid userId);

        public Task<List<GamesMark>> GetByGameIdAsync(Guid gameId);
    }
}
