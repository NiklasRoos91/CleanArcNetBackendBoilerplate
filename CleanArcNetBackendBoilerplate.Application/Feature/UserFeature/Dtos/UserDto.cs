using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Email Email { get; set; }
    }
}