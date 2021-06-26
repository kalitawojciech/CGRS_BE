using System;

namespace CGRS.Domain.Entities
{
    public class GamesTags
    {
        public Guid Id { get; set; }

        public Guid GameId { get; set; }

        public Guid TagId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
