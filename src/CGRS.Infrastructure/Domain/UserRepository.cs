using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using CGRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User userFromDB = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            // User userFromDB = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLowerInvariant() == email.ToLowerInvariant());

            return userFromDB;
        }

        public async Task<User> GetByEmailForAuthenticationAsync(string email)
        {
            User userFromDB = await _context.Users
                .Include(u => u.Identity)
                .FirstOrDefaultAsync(u => u.Email == email);

            return userFromDB;
        }

        public async Task<User> GetByNickAsync(string nick)
        {
            // User userFromDB = await _context.Users.FirstOrDefaultAsync(u => u.Nick.ToLowerInvariant() == nick.ToLowerInvariant());
            User userFromDB = await _context.Users.FirstOrDefaultAsync(u => u.Nick == nick);

            return userFromDB;
        }
    }
}
