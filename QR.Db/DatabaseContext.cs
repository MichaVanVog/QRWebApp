using Microsoft.EntityFrameworkCore;
using QR.Db.Models;

namespace QR.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
