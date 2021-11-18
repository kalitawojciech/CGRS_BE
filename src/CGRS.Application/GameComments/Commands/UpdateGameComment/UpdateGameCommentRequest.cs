using System;

namespace CGRS.Application.GameComments.Commands.UpdateGameComment
{
    public class UpdateGameCommentRequest
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public Guid GameId { get; set; }
    }
}
