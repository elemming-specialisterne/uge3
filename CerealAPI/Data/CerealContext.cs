using Microsoft.EntityFrameworkCore;

namespace CerealAPI.Data
{
    public class CerealContext(DbContextOptions<CerealContext> options) : DbContext(options)
    {
        public DbSet<Model.Cereal> Cereals { get; set; }
        public DbSet<Model.Manufacturer> Manufacturers { get; set; }
        public DbSet<Model.Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Manufacturer>()
                .HasKey(m => m.Shortform);

            modelBuilder.Entity<Model.Type>()
                .HasKey(t => t.Shortform);

            modelBuilder.Entity<Model.Cereal>()
                .HasKey(c => c.Id);
            
        }
    }
}