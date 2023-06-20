using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Tags;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Tags.Queries.GetTagById
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagInfoResponse>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagInfoResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            Tag tagFromDB = await _tagRepository.GetByIdAsync(request.Id);

            if (tagFromDB == null)
            {
                throw new NotFoundException();
            }

            var result = _mapper.Map<TagInfoResponse>(tagFromDB);
            return result;
        }
    }
}
