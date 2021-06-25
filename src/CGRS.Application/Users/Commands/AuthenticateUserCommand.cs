using CGRS.Application.Dtos.Users;
using MediatR;

namespace CGRS.Application.Users.Commands
{
    public class AuthenticateUserCommand : IRequest<LoggedInUserResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public AuthenticateUserCommand(UserAuthenticationRequest userAuthenticationRequest)
        {
            Email = userAuthenticationRequest.Email;
            Password = userAuthenticationRequest.Password;
        }
    }
}
