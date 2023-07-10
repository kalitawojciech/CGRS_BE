using System;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IIdentityRepository
    {
        Task AddAsync(UsersIdentity identity);

        Task<UsersIdentity> GetByUserIdAsync(Guid userId);

        Task SaveChangesAsync();
    }
}
