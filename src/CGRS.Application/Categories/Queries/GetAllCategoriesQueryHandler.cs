using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CGRS.Application.Dtos.Categories;
using CGRS.Domain.Entities;
using CGRS.Domain.Interfaces;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryInfoResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryInfoResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categoriesFromDb = await _categoryRepository.GetAllAsync();

            var result = _mapper.Map<List<CategoryInfoResponse>>(categoriesFromDb);
            return result;
        }
    }
}
