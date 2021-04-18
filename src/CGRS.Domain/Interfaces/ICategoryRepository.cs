using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task Add(Category category);
    }
}
