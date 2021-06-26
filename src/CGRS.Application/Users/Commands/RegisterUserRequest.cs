using System;

namespace CGRS.Application.Users.Commands
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }

        public string Nick { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }
    }
}