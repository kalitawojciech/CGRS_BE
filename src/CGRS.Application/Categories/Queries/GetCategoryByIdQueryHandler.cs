using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Categories;
using CGRS.Application.Exceptions;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryInfoResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryInfoResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category categoryFromDb = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryFromDb == null)
            {
                throw new NotFoundException();
            }

            var result = _mapper.Map<CategoryInfoResponse>(categoryFromDb);
            return result;
        }
    }
}
