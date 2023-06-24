using System;
using System.Collections.Generic;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class Game
    {
        public Game()
        {
            GamesComments = new HashSet<GamesComment>();
            GamesMarks = new HashSet<GamesMark>();
            GamesTags = new HashSet<GamesTag>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public decimal? AverageScore { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<GamesComment> GamesComments { get; set; }

        public virtual ICollection<GamesMark> GamesMarks { get; set; }

        public virtual ICollection<GamesTag> GamesTags { get; set; }
    }
}
