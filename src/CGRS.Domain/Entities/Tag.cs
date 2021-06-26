using System;
using System.Collections.Generic;

namespace CGRS.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            GamesTags = new HashSet<GamesTags>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<GamesTags> GamesTags { get; set; }
    }
}
