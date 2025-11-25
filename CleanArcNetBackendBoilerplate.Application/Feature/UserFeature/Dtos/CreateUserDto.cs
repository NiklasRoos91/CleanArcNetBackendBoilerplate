using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
