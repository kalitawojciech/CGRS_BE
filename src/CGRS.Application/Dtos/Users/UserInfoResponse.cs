using System;

namespace CGRS.Application.Dtos.Users
{
    public class UserInfoResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nick { get; set; }

        public string Role { get; set; }
    }
}
