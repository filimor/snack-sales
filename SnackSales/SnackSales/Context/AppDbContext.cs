using Microsoft.EntityFrameworkCore;
using SnackSales.Models;

namespace SnackSales.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Snack> Snacks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}