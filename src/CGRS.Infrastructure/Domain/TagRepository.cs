using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Domain
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public void Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await _context.Tags
                 .Where(c => c.Name == name)
                 .FirstOrDefaultAsync();
        }
    }
}
