using System.Security.Claims;
using CGRS.Application.Dtos.Users;
using MediatR;

namespace CGRS.Application.Users.Queries.GetCurrentUserData
{
    public class GetCurrentUserDataQuery : IRequest<UserProfileResponse>
    {
        public ClaimsPrincipal User { get; set; }

        public GetCurrentUserDataQuery(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
