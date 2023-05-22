using System.Collections.Generic;
using CGRS.Application.Dtos.Games;
using MediatR;

namespace CGRS.Application.Games.Queries.GetNamesFiltered
{
    public class GetNamesFilteredQuery : IRequest<List<GameNameResponse>>
    {
        public string Name { get; set; }

        public GetNamesFilteredQuery(string name)
        {
            Name = name;
        }
    }
}
