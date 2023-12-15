using Microsoft.EntityFrameworkCore;
using universal_windows_platform_c_.Core.Models;

namespace Migration.PostgreSQL
{
    public class UWPContext : DbContext
    {
        protected static string configDB = "Host=localhost;Username=postgres;Password=root;Database=UWP_CS";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(company => { });
            modelBuilder.Entity<Order>(order => { });
            modelBuilder.Entity<Product>(product => { });
            base.OnModelCreating(modelBuilder);
        }

        public static string GetConfigDB()
        {
            return configDB;
        }
    }
}