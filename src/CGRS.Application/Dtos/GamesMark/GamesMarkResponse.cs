using System;

namespace CGRS.Application.Dtos.GamesMark
{
    public class GamesMarkResponse
    {
        public Guid Id { get; set; }

        public decimal AverageScore { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }
    }
}
