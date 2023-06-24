using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Tags;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagInfoResponse>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetAllTagsQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<List<TagInfoResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            List<Tag> tagsFromDb = await _tagRepository.GetAllAsync();

            var result = _mapper.Map<List<TagInfoResponse>>(tagsFromDb);
            return result;
        }
    }
}
