using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;

namespace CGRS.Infrastructure.Domain
{
    public class GamesTagRepository : IGamesTagRepository
    {
        private readonly AppDbContext _context;

        public GamesTagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<GamesTag> gamesTags)
        {
            await _context.GamesTags.AddRangeAsync(gamesTags);
            await _context.SaveChangesAsync();
        }

        public void RemoveRange(List<GamesTag> gamesTags)
        {
            _context.GamesTags.RemoveRange(gamesTags);
            _context.SaveChanges();
        }
    }
}
