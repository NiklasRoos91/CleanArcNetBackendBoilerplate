using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using CleanArcNetBackendBoilerplate.Domain.ValueObjects;
using CleanArcNetBackendBoilerplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace CleanArcNetBackendBoilerplate.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

            return user;
        }
    }
}