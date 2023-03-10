using System;
using System.Collections.Generic;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            GamesComments = new HashSet<GamesComment>();
            GamesMarks = new HashSet<GamesMark>();
        }

        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        public string Email { get; set; }

        public string Nick { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsAdult { get; set; }

        public string Role { get; set; }

        public virtual UsersIdentity Identity { get; set; }

        public virtual ICollection<GamesComment> GamesComments { get; set; }

        public virtual ICollection<GamesMark> GamesMarks { get; set; }
    }
}
