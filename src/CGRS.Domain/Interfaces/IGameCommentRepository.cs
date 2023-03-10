using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGameCommentRepository
    {
        public Task AddAsync(GamesComment gameComment);

        public Task SaveChangesAsync();

        public Task<GamesComment> GetByIdAsync(Guid id);

        public Task<List<GamesComment>> GetByGameIdAsync(Guid gameId);

        void Delete(GamesComment gameComment);
    }
}
