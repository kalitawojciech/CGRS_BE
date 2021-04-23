using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(Guid id);

        void Delete(Category category);

        Task AddAsync(Category category);

        Task SaveChangesAsync();
    }
}
