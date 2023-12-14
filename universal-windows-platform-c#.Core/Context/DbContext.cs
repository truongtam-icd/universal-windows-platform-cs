using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;
using universal_windows_platform_c_.Core.Models;

namespace UWPApp.PostgreSQL
{
    public class UWPContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString;
            var connectionStrings = ConfigurationManager.ConnectionStrings;
            connString = connectionStrings["PostgreSQLConnectionString"].ToString();
            optionsBuilder.UseNpgsql(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(company => { });
            modelBuilder.Entity<Order>(order => { });
            modelBuilder.Entity<Product>(product => { });
            base.OnModelCreating(modelBuilder);
        }
    }
}