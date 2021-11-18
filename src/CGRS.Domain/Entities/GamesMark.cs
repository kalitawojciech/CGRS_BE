using System;

namespace CGRS.Domain.Entities
{
    public partial class GamesMark
    {
        public Guid Id { get; set; }

        public decimal AverageScore { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public virtual Game Game { get; set; }

        public virtual User User { get; set; }
    }
}
