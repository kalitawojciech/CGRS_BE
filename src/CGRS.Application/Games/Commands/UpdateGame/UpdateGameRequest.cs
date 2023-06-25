using System;
using System.Collections.Generic;

namespace CGRS.Application.Games.Commands.UpdateGame
{
    public class UpdateGameRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public List<Guid> TagsIds { get; set; }
    }
}
