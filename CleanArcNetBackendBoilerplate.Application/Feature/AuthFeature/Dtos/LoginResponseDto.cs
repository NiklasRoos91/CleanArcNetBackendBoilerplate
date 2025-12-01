namespace CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Dtos
{
    public class LoginResponseDto
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
