using System;
using MediatR;

namespace CGRS.Application.Categories.Commands.ChangeActivityStatus
{
    public class ChangeCategoryActiveStatusCommand : IRequest
    {
        public Guid Id { get; set; }

        public ChangeCategoryActiveStatusCommand(Guid id)
        {
            Id = id;
        }
    }
}
