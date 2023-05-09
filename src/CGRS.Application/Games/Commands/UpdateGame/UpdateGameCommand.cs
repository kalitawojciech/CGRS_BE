using System;
using MediatR;

namespace CGRS.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public UpdateGameCommand(UpdateGameRequest updateGameRequest)
        {
            Id = updateGameRequest.Id;
            Name = updateGameRequest.Name;
            Description = updateGameRequest.Description;
            IsAdultOnly = updateGameRequest.IsAdultOnly;
            CategoryId = updateGameRequest.CategoryId;
        }
    }
}
