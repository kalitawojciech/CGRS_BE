using System.Collections.Generic;
using CGRS.Domain.Entities;
using MediatR;

namespace CGRS.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }
}
