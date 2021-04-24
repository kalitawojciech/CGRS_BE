using System;
using MediatR;

namespace CGRS.Application.Games.Commands
{
    public class UpdateGameCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdultOnly { get; set; }

        public Guid CategoryId { get; set; }

        public UpdateGameCommand(Guid id, string name, string desctiption, bool isActive, bool isAdultOnly, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = desctiption;
            IsActive = isActive;
            IsAdultOnly = isAdultOnly;
            CategoryId = categoryId;
        }
    }
}
