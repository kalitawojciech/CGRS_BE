using System;
using System.Collections.Generic;
using System.Text;
using CGRS.Application.Dtos.Users;

namespace CGRS.Application.Dtos.GameComments
{
    public class GameCommentResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public UserInfoResponse User { get; set; }
    }
}
