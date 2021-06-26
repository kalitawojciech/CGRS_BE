using System.Collections.Generic;
using CGRS.Application.Dtos.Users;
using MediatR;

namespace CGRS.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserInfoResponse>>
    {
    }
}
