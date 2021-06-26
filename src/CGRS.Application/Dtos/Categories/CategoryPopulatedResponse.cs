using System;
using System.Collections.Generic;
using CGRS.Application.Dtos.Games;

namespace CGRS.Application.Dtos.Categories
{
    public class CategoryPopulatedResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<GameInfoResponse> Games { get; set; }
    }
}
