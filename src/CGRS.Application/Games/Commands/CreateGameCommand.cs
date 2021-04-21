using System;
using MediatR;

namespace CGRS.Application.Games.Commands
{
    public class CreateGameCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public CreateGameCommand(string name, string description, bool isAdultOnly, Guid categoryId)
        {
            Name = name;
            Description = description;
            IsAdultOnly = isAdultOnly;
            CategoryId = categoryId;
        }
    }
}
