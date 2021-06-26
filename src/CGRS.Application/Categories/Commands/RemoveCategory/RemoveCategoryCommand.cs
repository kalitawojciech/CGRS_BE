using System;
using MediatR;

namespace CGRS.Application.Categories.Commands.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
