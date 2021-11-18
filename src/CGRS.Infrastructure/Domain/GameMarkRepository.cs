using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Domain
{
    public class GameMarkRepository : IGameMarkRepository
    {
        private readonly AppDbContext _context;

        public GameMarkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GamesMark gameMark)
        {
            await _context.GamesMarks.AddAsync(gameMark);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GamesMark>> GetByGameIdAsync(Guid gameId)
        {
            return await _context.GamesMarks.Where(gm => gm.GameId == gameId).ToListAsync();
        }

        public async Task<GamesMark> GetByIdAsync(Guid id)
        {
            return await _context.GamesMarks.Where(gm => gm.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
