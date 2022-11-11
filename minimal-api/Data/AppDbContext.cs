using Microsoft.EntityFrameworkCore;

namespace minimal_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<pessoa> pessoas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
