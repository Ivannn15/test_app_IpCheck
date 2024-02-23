using Microsoft.EntityFrameworkCore;

namespace test_app_IpCheck.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<RequestHistory> RequestHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=lite.db"); // Настройка подключения к базе данных SQLite
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestHistory>().HasKey(r => r.Id); // Настройка первичного ключа для сущности RequestHistory
        }
    }
}