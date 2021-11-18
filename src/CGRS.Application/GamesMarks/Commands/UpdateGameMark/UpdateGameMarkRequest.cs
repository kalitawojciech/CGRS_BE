using System;

namespace CGRS.Application.GamesMarks.Commands.UpdateGameMark
{
    public class UpdateGameMarkRequest
    {
        public Guid Id { get; set; }

        public decimal AverageScore { get; set; }

        public Guid GameId { get; set; }
    }
}
