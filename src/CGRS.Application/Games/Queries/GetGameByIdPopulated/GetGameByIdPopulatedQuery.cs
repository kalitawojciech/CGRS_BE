using System;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetGameByIdPopulated
{
    public class GetGameByIdPopulatedQuery : IRequest<GamePopulatedResponse>
    {
        public Guid Id { get; set; }

        public GetGameByIdPopulatedQuery(Guid id)
        {
            Id = id;
        }
    }
}
