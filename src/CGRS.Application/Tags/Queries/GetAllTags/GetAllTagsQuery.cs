using System.Collections.Generic;
using CGRS.Application.Dtos.Tags;
using MediatR;

namespace CGRS.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsQuery : IRequest<List<TagInfoResponse>>
    {
    }
}
