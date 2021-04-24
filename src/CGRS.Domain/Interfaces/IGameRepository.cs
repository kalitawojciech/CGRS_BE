using System;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task AddAsync(Game game);

        Task<Game> GetByIdAsync(Guid id);

        Task SaveChangesAsync();
    }
}
