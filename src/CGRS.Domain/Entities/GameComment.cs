using System;

namespace CGRS.Domain.Entities
{
    public class GameComment
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public virtual Game Game { get; set; }

        public virtual User User { get; set; }
    }
}
