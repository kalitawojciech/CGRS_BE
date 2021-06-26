using System.Collections.Generic;
using CGRS.Application.Dtos.Categories;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryInfoResponse>>
    {
    }
}
