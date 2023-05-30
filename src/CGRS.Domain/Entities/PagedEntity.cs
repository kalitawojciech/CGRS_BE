using System.Collections.Generic;

namespace CGRS.Domain.Entities
{
    public class PagedEntity<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int TotalDataCount { get; set; }
    }
}
