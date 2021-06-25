using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByEmailForAuthenticationAsync(string email);

        Task<User> GetByNickAsync(string nick);
    }
}
