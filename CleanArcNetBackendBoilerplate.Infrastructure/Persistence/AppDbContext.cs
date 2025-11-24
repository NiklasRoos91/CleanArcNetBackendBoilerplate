using Microsoft.EntityFrameworkCore;
using CleanArcNetBackendBoilerplate.Domain.Entities
;

namespace CleanArcNetBackendBoilerplate.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
