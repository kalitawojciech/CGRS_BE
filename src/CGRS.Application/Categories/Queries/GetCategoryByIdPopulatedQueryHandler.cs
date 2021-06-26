using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Categories;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetCategoryByIdPopulatedQueryHandler : IRequestHandler<GetCategoryByIdPopulatedQuery, CategoryPopulatedResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdPopulatedQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryPopulatedResponse> Handle(GetCategoryByIdPopulatedQuery request, CancellationToken cancellationToken)
        {
            Category categoryFromDb = await _categoryRepository.GetByIdAsync(request.Id);

            var result = _mapper.Map<CategoryPopulatedResponse>(categoryFromDb);
            return result;
        }
    }
}
