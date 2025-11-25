using CleanArcNetBackendBoilerplate.Domain.ValueObjects;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CleanArcNetBackendBoilerplate.Application")]

namespace CleanArcNetBackendBoilerplate.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Email Email { get; set; }

        public string PasswordHash { get; internal set; } = string.Empty;
    }
}
