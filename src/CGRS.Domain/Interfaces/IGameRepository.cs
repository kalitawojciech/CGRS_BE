using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task Add(Game game);
    }
}
