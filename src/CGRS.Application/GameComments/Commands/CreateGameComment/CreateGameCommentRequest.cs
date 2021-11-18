using System;

namespace CGRS.Application.GameComments.Commands.CreateGameComment
{
    public class CreateGameCommentRequest
    {
        public string Message { get; set; }

        public Guid GameId { get; set; }
    }
}
