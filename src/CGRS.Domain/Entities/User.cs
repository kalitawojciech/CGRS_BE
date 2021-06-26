using System;

namespace CGRS.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        public string Email { get; set; }

        public string Nick { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsAdult { get; set; }

        public string Role { get; set; }

        public virtual Identity Identity { get; set; }
    }
}
