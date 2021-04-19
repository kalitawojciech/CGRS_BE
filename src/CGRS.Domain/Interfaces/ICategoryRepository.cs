using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;

namespace CGRS.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(Guid id);

        void Delete(Category category);

        Task Add(Category category);

        Task SaveChanges();

    }
}
