using Microsoft.EntityFrameworkCore;

namespace Gear1API.Data{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Gear> Pirates{get; set;}
    }
}