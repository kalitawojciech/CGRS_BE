using System;
using MediatR;

namespace CGRS.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }

        public string Nick { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public RegisterUserCommand(RegisterUserRequest registerUserRequest)
        {
            Email = registerUserRequest.Email;
            Nick = registerUserRequest.Nick;
            BirthDate = registerUserRequest.BirthDate;
            Password = registerUserRequest.Password;
        }
    }
}
