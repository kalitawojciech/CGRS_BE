using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IIdentityRepository
    {
        Task AddAsync(UsersIdentity identity);
    }
}
