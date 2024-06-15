using BoostlingoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BoostlingoApp.Infrastructure.Repository
{
    public class BoostlingoDBContext : DbContext
    {
        private readonly string _connectionString;
        public BoostlingoDBContext(IConfiguration config) 
        {
            _connectionString = config["ConnectionString"];
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new Exception("Connection string is not configured in appsettings.json");
            }
        }

        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("User");
        }
    }
}
