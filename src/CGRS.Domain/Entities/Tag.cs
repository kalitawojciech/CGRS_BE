using System;
using System.Collections.Generic;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            GamesTags = new HashSet<GamesTag>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<GamesTag> GamesTags { get; set; }
    }
}
