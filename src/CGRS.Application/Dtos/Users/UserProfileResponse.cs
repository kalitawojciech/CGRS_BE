using System;

namespace CGRS.Application.Dtos.Users
{
    public class UserProfileResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nick { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
