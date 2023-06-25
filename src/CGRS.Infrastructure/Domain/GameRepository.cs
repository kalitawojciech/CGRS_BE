using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Filters;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Domain
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games
                .Include(g => g.Category)
                .Include(g => g.GamesMarks)
                .OrderByDescending(g => g.IsActive)
                .ThenBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<PagedEntity<Game>> GetFilteredAsync(GamesFilter filter, ClaimsPrincipal user)
        {
            IQueryable<Game> query = _context.Games;

            if (string.IsNullOrEmpty(filter.CategoryId))
            {
                var categoryId = new Guid(filter.CategoryId);
                query = query.Where(g => g.Category.Id == categoryId);
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(g => g.IsActive == filter.IsActive);
            }

            var allRecordsCount = query.Count();

            if (filter.PageNumber != null && filter.PageSize != null)
            {
                query = query.Skip((filter.PageNumber.Value) * filter.PageSize.Value).Take(filter.PageSize.Value);
            }

            var results = await query.Include(g => g.Category)
                .OrderByDescending(g => g.IsActive)
                .ThenBy(g => g.Name)
                .ToListAsync();

            return new PagedEntity<Game>() { Results = results, TotalDataCount = allRecordsCount };
        }

        public async Task<Game> GetByIdAsync(Guid id)
        {
            return await _context.Games
                .Include(g => g.Category)
                .Where(c => c.Id == id)
                .Include(g => g.GamesTags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync();
        }

        public async Task<Game> GetByIdPopulatedAsync(Guid id)
        {
            return await _context.Games
                .Include(g => g.Category)
                .Include(g => g.GamesComments)
                .ThenInclude(c => c.User)
                .Include(g => g.GamesTags)
                .ThenInclude(t => t.Tag)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Game> GetByNameAsync(string name)
        {
            return await _context.Games
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task<List<Game>> GetByNameFilteredAsync(string name)
        {
            return await _context.Games
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public void RemoveGame(Game gameToRemove)
        {
            _context.Remove(gameToRemove);
            _context.SaveChanges();
        }

        public void RemoveGames(List<Game> gamesToRemove)
        {
            _context.RemoveRange(gamesToRemove);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
