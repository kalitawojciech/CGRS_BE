using System;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class GamesTag
    {
        public Guid GameId { get; set; }

        public Guid TagId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
