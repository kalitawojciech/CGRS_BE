using System;

namespace CGRS.RestApi.RestModels.Games
{
    public class CreateGameRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }
    }
}
