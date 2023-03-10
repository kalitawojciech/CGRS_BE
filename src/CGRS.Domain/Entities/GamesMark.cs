using System;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class GamesMark
    {
        public Guid Id { get; set; }

        public decimal? Score { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public virtual Game Game { get; set; }

        public virtual User User { get; set; }
    }
}
