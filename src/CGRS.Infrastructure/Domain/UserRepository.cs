using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Filters;
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
            return await _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
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
            return await _context.Users.Where(u => u.Nick.ToLower() == nick.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<PagedEntity<User>> GetFilteredAsync(UsersFilter filter)
        {
            IQueryable<User> query = _context.Users;

            if (!string.IsNullOrEmpty(filter.NickOrEmail))
            {
                var sentence = filter.NickOrEmail.ToLowerInvariant();
                query = query.Where(u => EF.Functions.ILike(u.Nick, $"%{sentence}%") || EF.Functions.ILike(u.Email, $"%{sentence}%"));
            }

            var allRecordsCount = query.Count();

            if (filter.PageNumber != null && filter.PageSize != null)
            {
                query = query.Skip((filter.PageNumber.Value) * filter.PageSize.Value).Take(filter.PageSize.Value);
            }

            var results = await query
                .OrderByDescending(u => u.Nick)
                .ToListAsync();

            return new PagedEntity<User>() { Results = results, TotalDataCount = allRecordsCount };
        }
    }
}
