using Microsoft.EntityFrameworkCore;

namespace DataApp.Models
{
    public class EFDatabaseContext : DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opts)
            : base(opts) {}

        public DbSet<Product> Products { get; set; }
    }
}
