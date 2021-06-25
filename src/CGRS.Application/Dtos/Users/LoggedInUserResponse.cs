using System;

namespace CGRS.Application.Dtos.Users
{
    public class LoggedInUserResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }
}
