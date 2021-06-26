using System;
using CGRS.Application.Dtos.Categories;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetCategoryByIdPopulatedQuery : IRequest<CategoryPopulatedResponse>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdPopulatedQuery(Guid id)
        {
            Id = id;
        }
    }
}
