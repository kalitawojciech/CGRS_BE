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
    public class GameCommentRepository : IGameCommentRepository
    {
        private readonly AppDbContext _context;

        public GameCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GamesComment gameComment)
        {
            await _context.GamesComments.AddAsync(gameComment);
            await _context.SaveChangesAsync();
        }

        public void Delete(GamesComment gameComment)
        {
            _context.GamesComments.Remove(gameComment);
            _context.SaveChanges();
        }

        public async Task<List<GamesComment>> GetByGameIdAsync(Guid gameId)
        {
            return await _context.GamesComments.Where(gm => gm.GameId == gameId).ToListAsync();
        }

        public async Task<GamesComment> GetByIdAsync(Guid id)
        {
            return await _context.GamesComments.Where(gm => gm.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
