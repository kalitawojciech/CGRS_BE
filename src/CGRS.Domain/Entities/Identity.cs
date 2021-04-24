using System;

namespace CGRS.Domain.Entities
{
    public class Identity
    {
        public Guid Id { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; }

        public virtual User User { get; set; }
    }
}
