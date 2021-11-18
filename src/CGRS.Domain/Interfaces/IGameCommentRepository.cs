using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGameCommentRepository
    {
        public Task AddAsync(GameComment gameComment);

        public Task SaveChangesAsync();

        public Task<GameComment> GetByIdAsync(Guid id);

        public Task<List<GameComment>> GetByGameIdAsync(Guid gameId);

        void Delete(GameComment gameComment);
    }
}
