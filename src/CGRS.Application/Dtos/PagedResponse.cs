using System.Collections.Generic;

namespace CGRS.Application.Dtos
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalDataCount { get; set; }
    }
}
