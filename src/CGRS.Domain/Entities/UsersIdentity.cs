using System;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class UsersIdentity
    {
        public Guid Id { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual User User { get; set; }
    }
}
