using System;

namespace CGRS.RestApi.RestModels.Games
{
    public class UpdateGameRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }
    }
}
