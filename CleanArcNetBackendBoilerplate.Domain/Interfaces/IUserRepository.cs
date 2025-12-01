using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    }
}
