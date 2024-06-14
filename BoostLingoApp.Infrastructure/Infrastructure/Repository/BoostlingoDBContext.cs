using BoostlingoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoostlingoApp.Infrastructure.Repository
{
    public class BoostlingoDBContext : DbContext
    {
        public BoostlingoDBContext(DbContextOptions<BoostlingoDBContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("User");
        }
    }
}
