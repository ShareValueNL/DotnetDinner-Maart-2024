// DinnerDbContext.cs
using Microsoft.EntityFrameworkCore;
using DotnetDinnerApi.Models;

namespace DotnetDinnerApi
{
    public class DinnerDbContext : DbContext
    {
        public DinnerDbContext(DbContextOptions<DinnerDbContext> options) : base(options) { }

        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, Name = "John Doe" },
                new Visitor { Id = 2, Name = "Jane Doe" }
                // Add more visitors here
            );
        }
    }
}