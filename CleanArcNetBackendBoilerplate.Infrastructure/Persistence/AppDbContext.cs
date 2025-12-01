using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArcNetBackendBoilerplate.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var emailConverter = new ValueConverter<Email, string>(
                v => v.Value, 
                v => new Email(v)); 

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasConversion(emailConverter)
                .HasColumnName("Email");
        }
    }
}
