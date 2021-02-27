using Microsoft.EntityFrameworkCore;

namespace CGRS.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
