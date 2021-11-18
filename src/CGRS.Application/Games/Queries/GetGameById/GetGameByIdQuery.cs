using System;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetGameById
{
    public class GetGameByIdQuery : IRequest<GameInfoResponse>
    {
        public Guid Id { get; set; }

        public GetGameByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
