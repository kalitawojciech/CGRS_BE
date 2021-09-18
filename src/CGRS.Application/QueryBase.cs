using MediatR;

namespace CGRS.Application
{
    public class QueryBase<T> : IRequest<T>
    {
        public int PageNumber { get; set; }

        public int ElementsOnPage { get; set; }

        public QueryBase(int pageNumber, int elementsOnPage)
        {
            PageNumber = pageNumber;
            ElementsOnPage = elementsOnPage;
        }
    }
}
