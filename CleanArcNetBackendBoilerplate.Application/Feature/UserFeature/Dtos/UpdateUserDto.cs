using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
