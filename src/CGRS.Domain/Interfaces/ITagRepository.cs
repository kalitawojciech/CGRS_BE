using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();

        Task AddAsync(Tag tag);

        void Delete(Tag tag);

        Task SaveChangesAsync();

        Task<Tag> GetByNameAsync(string name);
    }
}
