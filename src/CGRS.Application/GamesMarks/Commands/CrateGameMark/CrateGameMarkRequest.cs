using System;

namespace CGRS.Application.GamesMarks.Commands.CrateGameMark
{
    public class CrateGameMarkRequest
    {
        public decimal AverageScore { get; set; }

        public Guid GameId { get; set; }
    }
}
