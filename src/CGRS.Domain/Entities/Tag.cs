using System;

#nullable disable

namespace CGRS.Domain.Entities
{
    public partial class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
}
