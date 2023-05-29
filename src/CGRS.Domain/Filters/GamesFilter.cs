namespace CGRS.Domain.Filters
{
    public class GamesFilter : FilterBase
    {
        public bool? IsActive { get; set; }

        public string CategoryId { get; set; }
    }
}
