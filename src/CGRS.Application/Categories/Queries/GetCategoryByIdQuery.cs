using System;
using CGRS.Application.Dtos.Categories;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryInfoResponse>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
