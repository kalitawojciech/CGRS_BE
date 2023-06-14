using System.Collections.Generic;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Users;
using CGRS.Domain.Filters;
using MediatR;

namespace CGRS.Application.Users.Queries
{
    public class GetFilteredUsersQuery : IRequest<PagedResponse<UserFullInfoResponse>>
    {
        public UsersFilter UsersFilter { get; set; }

        public GetFilteredUsersQuery(UsersFilter usersFilter)
        {
            UsersFilter = usersFilter;
        }
    }
}
