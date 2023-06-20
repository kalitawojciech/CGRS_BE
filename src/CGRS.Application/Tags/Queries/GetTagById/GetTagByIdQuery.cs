using System;
using CGRS.Application.Dtos.Tags;
using MediatR;

namespace CGRS.Application.Tags.Queries.GetTagById
{
    public class GetTagByIdQuery : IRequest<TagInfoResponse>
    {
        public Guid Id { get; set; }

        public GetTagByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
