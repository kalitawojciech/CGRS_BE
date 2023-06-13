﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CGRS.Domain.Entities;
using CGRS.Domain.Filters;

namespace CGRS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByEmailForAuthenticationAsync(string email);

        Task<User> GetByNickAsync(string nick);

        Task<List<User>> GetAllAsync();

        Task<PagedEntity<User>> GetFilteredAsync(UsersFilter filter);
    }
}
