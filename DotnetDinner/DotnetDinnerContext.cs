using Microsoft.EntityFrameworkCore;

namespace DotnetDinner
{
    public class DinnerDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }

        public DinnerDbContext(DbContextOptions<DinnerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, Name = "Addy Tas" },
                new Visitor { Id = 2, Name = "Adric Walter" },
                new Visitor { Id = 3, Name = "Bas Dorresteijn" },
                new Visitor { Id = 4, Name = "Bas Tesselaar" },
                new Visitor { Id = 5, Name = "Benjamin van der Kwaak" },
                new Visitor { Id = 6, Name = "Boris Enthoven" },
                new Visitor { Id = 7, Name = "Daniel Paulus" },
                new Visitor { Id = 8, Name = "Ehstesam Ahmed" },
                new Visitor { Id = 9, Name = "Faisal Hossaien" }
            );
        }
    }
}