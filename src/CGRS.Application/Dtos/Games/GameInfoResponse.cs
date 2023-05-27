using System;
using CGRS.Application.Dtos.GamesMark;

namespace CGRS.Application.Dtos.Games
{
    public class GameInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public decimal? AverageScore { get; set; }

        public bool? IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public GameMarkResponse GameMarkResponse { get; set; }
    }
}
