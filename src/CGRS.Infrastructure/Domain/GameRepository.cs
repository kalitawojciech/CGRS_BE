using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;

namespace CGRS.Infrastructure.Domain
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
    }
}
