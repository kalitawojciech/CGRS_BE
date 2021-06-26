using System;
using System.Collections.Generic;

namespace CGRS.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
