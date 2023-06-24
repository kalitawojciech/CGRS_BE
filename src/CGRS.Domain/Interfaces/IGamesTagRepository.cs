using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGamesTagRepository
    {
        Task AddRangeAsync(List<GamesTag> gamesTags);

        void RemoveRange(List<GamesTag> gamesTags);
    }
}
