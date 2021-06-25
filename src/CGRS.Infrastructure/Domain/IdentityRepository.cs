using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;

namespace CGRS.Infrastructure.Domain
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly AppDbContext _context;

        public IdentityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Identity identity)
        {
            await _context.Identities.AddAsync(identity);
            await _context.SaveChangesAsync();
        }
    }
}
