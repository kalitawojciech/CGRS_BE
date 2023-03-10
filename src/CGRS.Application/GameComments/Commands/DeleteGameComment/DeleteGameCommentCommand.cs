using System;
using MediatR;

namespace CGRS.Application.GameComments.Commands.DeleteGameComment
{
    public class DeleteGameCommentCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteGameCommentCommand(Guid id)
        {
            Id = id;
        }
    }
}
