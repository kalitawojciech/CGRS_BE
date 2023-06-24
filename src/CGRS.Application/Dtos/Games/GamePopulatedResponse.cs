using System;
using System.Collections.Generic;
using CGRS.Application.Dtos.Categories;
using CGRS.Application.Dtos.GameComments;
using CGRS.Application.Dtos.GamesMark;
using CGRS.Application.Dtos.Tags;

namespace CGRS.Application.Dtos.Games
{
    public class GamePopulatedResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public decimal? AverageScore { get; set; }

        public bool? IsAdultOnly { get; set; }

        public CategoryInfoResponse Category { get; set; }

        public List<GameCommentResponse> GamesComments { get; set; }

        public GameMarkResponse UserGameMark { get; set; }

        public List<TagInfoResponse> GameTags { get; set; }
    }
}
