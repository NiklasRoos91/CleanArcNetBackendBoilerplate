using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Domain.Entities;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Mappers
{
    public static class UserDtoMapper
    {
        public static UserDto Map(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
