using CleanArcNetBackendBoilerplate.Domain.Entities;

namespace CleanArcNetBackendBoilerplate.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken(User user);
        bool ValidateToken(string token);
    }
}