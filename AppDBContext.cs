namespace StrikkebutikkBackend
{
    using System;
    using System.Xml;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using StrikkebutikkBackend.Model;

    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<ProductWithForeignKey> Products { get; set; }
        public DbSet<Assortment> Assortments { get; set; }
        public DbSet<Pattern> Patterns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assortment>()
                .Property(e => e.id)
                .ValueGeneratedNever(); // This removes the identity behavior

            modelBuilder.Entity<Pattern>()
                .Property(e => e.id)
                .ValueGeneratedNever(); // This removes the identity behavior

            // Configure the foreign key relationship for ProductWithForeignKey and Pattern
            modelBuilder.Entity<ProductWithForeignKey>()
                .HasOne(p => p.pattern) // Define the relationship with Pattern
                .WithMany() // If Pattern has no collection property, use WithMany()
                .HasForeignKey(p => p.patternId) // Define the foreign key
                .OnDelete(DeleteBehavior.Restrict);  // Remove cascading delete

        }



    }
}
