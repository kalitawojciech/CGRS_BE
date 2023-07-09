using System.Security.Claims;
using MediatR;

namespace CGRS.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public ClaimsPrincipal User { get; set; }

        public ChangePasswordCommand(ChangePasswordRequest request, ClaimsPrincipal user)
        {
            OldPassword = request.OldPassword;
            NewPassword = request.NewPassword;
            User = user;
        }
    }
}
