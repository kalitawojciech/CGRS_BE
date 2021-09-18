using System;
using System.Collections.Generic;

namespace CGRS.Domain.Entities
{
    public partial class Game
    {
        public Game()
        {
            GamesMarks = new HashSet<GamesMark>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public decimal? AverageScore { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<GamesMark> GamesMarks { get; set; }
    }
}
