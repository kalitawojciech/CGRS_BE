using System;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class GamesComment
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public virtual Game Game { get; set; }

        public virtual User User { get; set; }
    }
}
