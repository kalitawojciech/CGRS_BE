using System;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Domain
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly AppDbContext _context;

        public IdentityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UsersIdentity identity)
        {
            await _context.UsersIdentities.AddAsync(identity);
            await _context.SaveChangesAsync();
        }

        public async Task<UsersIdentity> GetByUserIdAsync(Guid userId)
        {
            return await _context.UsersIdentities.FirstOrDefaultAsync(x => x.User.Id == userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
