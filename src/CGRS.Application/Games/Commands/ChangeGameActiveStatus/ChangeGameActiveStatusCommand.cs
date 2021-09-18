using System;
using MediatR;

namespace CGRS.Application.Games.Commands.ChangeGameActiveStatus
{
    public class ChangeGameActiveStatusCommand : IRequest
    {
        public Guid Id { get; set; }

        public ChangeGameActiveStatusCommand(Guid id)
        {
            Id = id;
        }
    }
}
