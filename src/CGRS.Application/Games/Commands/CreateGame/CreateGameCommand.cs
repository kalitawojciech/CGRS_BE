﻿using System;
using System.Collections.Generic;
using MediatR;

namespace CGRS.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public List<Guid> TagsIds { get; set; }

        public CreateGameCommand(CreateGameRequest createGameRequest)
        {
            Name = createGameRequest.Name;
            Description = createGameRequest.Description;
            IsAdultOnly = createGameRequest.IsAdultOnly;
            CategoryId = createGameRequest.CategoryId;
            TagsIds = createGameRequest.TagsIds;
        }
    }
}
