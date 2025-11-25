using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.ValueObjects;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Helpers
{
    public static class UserPatchHelper
    {
        public static void ApplyPatch(User user, UpdateUserDto dto)
        {
            if (!string.IsNullOrEmpty(dto.FirstName))
                user.FirstName = dto.FirstName;

            if (!string.IsNullOrEmpty(dto.LastName))
                user.LastName = dto.LastName;

            if (!string.IsNullOrEmpty(dto.Email))
                user.Email = new Email(dto.Email);
        }
    }
}
