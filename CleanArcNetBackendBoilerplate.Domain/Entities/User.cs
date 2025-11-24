using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Email Email { get; set; }

        public string PasswordHash { get; private set; } = string.Empty;
    }
}
