using System;

namespace CGRS.Application.Games.Queries.GetAllGames
{
    public class GamesFilter
    {
        public bool? IsActive { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
